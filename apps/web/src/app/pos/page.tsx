"use client";

import React, { useState, useEffect } from "react";
import Sidebar from "@/components/Sidebar";
import { Search, ShoppingCart, Trash2, Plus, Minus, CreditCard, CheckCircle2, AlertCircle, RefreshCw, UserCheck, Phone, UserPlus, X } from "lucide-react";

interface CartItem {
  variantId: number;
  productName: string;
  sku: string;
  size: string;
  color: string;
  price: number;
  quantity: number;
  stockQuantity: number;
}

interface ReceiptResponse {
  success: boolean;
  statusCode: number;
  orderId: number;
  orderCode: string;
  totalItemsAmount: number;
  finalAmount: number;
  paidAmount: number;
  changeAmount: number;
  earnedPoints: number;
}

interface UserInfo {
  employeeId: number;
  fullName: string;
  username: string;
  role: string;
  token: string;
}

interface CustomerInfo {
  customerId: number;
  fullName: string;
  phoneNumber: string;
  totalSpent: number;
  loyaltyPoints: number;
  membershipTier: string;
}

export default function PosPage() {
  const [skuSearch, setSkuSearch] = useState("SKU-AO-001-XAM-36");
  const [cart, setCart] = useState<CartItem[]>([]);
  const [discountValue, setDiscountValue] = useState<number>(0);
  const [paidAmount, setPaidAmount] = useState<number>(500000);
  const [paymentMethod, setPaymentMethod] = useState<string>("CASH");
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [errorMessage, setErrorMessage] = useState<string | null>(null);
  const [receiptData, setReceiptData] = useState<ReceiptResponse | null>(null);
  const [currentUser, setCurrentUser] = useState<UserInfo | null>(null);
  const [mobileTab, setMobileTab] = useState<"cart" | "payment">("cart");

  // Tra cứu Khách Hàng theo SĐT
  const [phoneSearch, setPhoneSearch] = useState("0906834761");
  const [selectedCustomer, setSelectedCustomer] = useState<CustomerInfo | null>(null);
  const [isSearchingCustomer, setIsSearchingCustomer] = useState<boolean>(false);
  const [showRegisterPrompt, setShowRegisterPrompt] = useState<boolean>(false);

  // Modal Đăng Ký Khách Hàng Mới Nhanh
  const [isCustomerModalOpen, setIsCustomerModalOpen] = useState<boolean>(false);
  const [newCustName, setNewCustName] = useState<string>("");
  const [newCustPhone, setNewCustPhone] = useState<string>("");
  const [isCreatingCustomer, setIsCreatingCustomer] = useState<boolean>(false);
  const [customerModalError, setCustomerModalError] = useState<string | null>(null);

  const getApiUrl = (endpoint: string) => {
    if (typeof window !== "undefined") {
      return `/api/v1${endpoint}`;
    }
    return `http://localhost:5000/api/v1${endpoint}`;
  };

  // Check auth user from localStorage
  useEffect(() => {
    const savedUser = localStorage.getItem("pos_user");
    if (savedUser) {
      try {
        setCurrentUser(JSON.parse(savedUser));
      } catch {
        setCurrentUser(null);
      }
    }
    handleSearchCustomerByPhone();
  }, []);

  // Tìm kiếm Khách Hàng theo SĐT
  const handleSearchCustomerByPhone = async (e?: React.FormEvent) => {
    if (e) e.preventDefault();
    if (!phoneSearch.trim()) return;

    setIsSearchingCustomer(true);
    setShowRegisterPrompt(false);

    try {
      let res = await fetch(getApiUrl(`/customers/phone/${encodeURIComponent(phoneSearch.trim())}`)).catch(() => null);
      if (!res || !res.ok) {
        res = await fetch(`http://localhost:5000/api/v1/customers/phone/${encodeURIComponent(phoneSearch.trim())}`);
      }

      const data = await res.json();

      if (res.ok && data.success) {
        setSelectedCustomer(data.data);
        setShowRegisterPrompt(false);
      } else {
        setSelectedCustomer(null);
        setShowRegisterPrompt(true);
      }
    } catch {
      setSelectedCustomer(null);
      setShowRegisterPrompt(true);
    } finally {
      setIsSearchingCustomer(false);
    }
  };

  // Mở Modal Đăng Ký Khách Mới
  const handleOpenRegisterModal = () => {
    setNewCustPhone(phoneSearch.trim());
    setNewCustName("");
    setCustomerModalError(null);
    setIsCustomerModalOpen(true);
  };

  // Đăng Ký Khách Mới Gọi API .NET 8
  const handleRegisterCustomer = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!newCustName.trim() || !newCustPhone.trim()) {
      setCustomerModalError("Vui lòng điền họ tên và số điện thoại!");
      return;
    }

    setIsCreatingCustomer(true);
    setCustomerModalError(null);

    const payload = {
      fullName: newCustName.trim(),
      phoneNumber: newCustPhone.trim(),
      gender: 1,
    };

    try {
      let res = await fetch(getApiUrl("/customers"), {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload),
      }).catch(() => null);

      if (!res || !res.ok) {
        res = await fetch("http://localhost:5000/api/v1/customers", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(payload),
        });
      }

      const data = await res.json();

      if (!res.ok || !data.success) {
        throw new Error(data.message || "Đăng ký thành viên thất bại!");
      }

      // Tự động chọn Khách vừa đăng ký cho đơn hàng POS
      setSelectedCustomer({
        customerId: data.data.customerId,
        fullName: data.data.fullName,
        phoneNumber: data.data.phoneNumber,
        totalSpent: 0,
        loyaltyPoints: 0,
        membershipTier: "BRONZE",
      });

      setShowRegisterPrompt(false);
      setIsCustomerModalOpen(false);
      setPhoneSearch(data.data.phoneNumber);
    } catch (err: unknown) {
      const msg = err instanceof Error ? err.message : "Đã có lỗi xảy ra!";
      setCustomerModalError(msg);
    } finally {
      setIsCreatingCustomer(false);
    }
  };

  // Hàm quét mã vạch SKU tìm sản phẩm
  const handleScanSku = async (e?: React.FormEvent) => {
    if (e) e.preventDefault();
    if (!skuSearch.trim()) return;

    setIsLoading(true);
    setErrorMessage(null);

    try {
      let res = await fetch(getApiUrl(`/variants/sku/${encodeURIComponent(skuSearch.trim())}`)).catch(() => null);
      if (!res || !res.ok) {
        res = await fetch(`http://localhost:5000/api/v1/variants/sku/${encodeURIComponent(skuSearch.trim())}`);
      }

      const data = await res.json();

      if (!res.ok || !data.success) {
        throw new Error(data.message || "Không tìm thấy mã vạch SKU này!");
      }

      const item = data.data;

      setCart((prevCart) => {
        const existingIndex = prevCart.findIndex((c) => c.variantId === item.variantId);
        if (existingIndex > -1) {
          const updated = [...prevCart];
          if (updated[existingIndex].quantity < item.stockQuantity) {
            updated[existingIndex].quantity += 1;
          } else {
            alert(`Sản phẩm SKU ${item.sku} đã đạt giới hạn tồn kho (${item.stockQuantity})!`);
          }
          return updated;
        } else {
          return [
            ...prevCart,
            {
              variantId: item.variantId,
              productName: item.productName,
              sku: item.sku,
              size: item.size,
              color: item.color,
              price: item.price,
              quantity: 1,
              stockQuantity: item.stockQuantity,
            },
          ];
        }
      });

      setSkuSearch("");
    } catch (err: unknown) {
      const msg = err instanceof Error ? err.message : "Đã có lỗi xảy ra";
      setErrorMessage(msg);
    } finally {
      setIsLoading(false);
    }
  };

  // Tính toán số tiền & điểm tích lũy
  const totalItemsAmount = cart.reduce((sum, item) => sum + item.price * item.quantity, 0);
  const finalAmount = Math.max(0, totalItemsAmount - discountValue);
  const changeAmount = Math.max(0, paidAmount - finalAmount);
  const estimatedEarnedPoints = Math.floor(finalAmount / 10000);

  // Tăng/Giảm số lượng
  const updateQuantity = (variantId: number, delta: number) => {
    setCart((prev) =>
      prev
        .map((item) => {
          if (item.variantId === variantId) {
            const newQty = item.quantity + delta;
            if (newQty > item.stockQuantity) {
              alert(`Tồn kho chỉ còn ${item.stockQuantity} sản phẩm!`);
              return item;
            }
            return { ...item, quantity: newQty };
          }
          return item;
        })
        .filter((item) => item.quantity > 0)
    );
  };

  // Xóa sản phẩm khỏi giỏ
  const removeItem = (variantId: number) => {
    setCart((prev) => prev.filter((item) => item.variantId !== variantId));
  };

  // Gọi API Thanh Toán (POS Checkout)
  const handleCheckout = async () => {
    if (cart.length === 0) {
      alert("Giỏ hàng đang trống!");
      return;
    }
    if (paidAmount < finalAmount) {
      alert("Số tiền khách đưa chưa đủ!");
      return;
    }

    setIsLoading(true);
    setErrorMessage(null);

    const payload = {
      employeeId: currentUser?.employeeId || 1,
      customerId: selectedCustomer?.customerId || 1,
      discountType: "PERCENT",
      discountValue: discountValue,
      paymentMethod: paymentMethod,
      paidAmount: paidAmount,
      items: cart.map((item) => ({
        variantId: item.variantId,
        quantity: item.quantity,
        unitPrice: item.price,
      })),
    };

    try {
      let res = await fetch(getApiUrl("/orders"), {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload),
      }).catch(() => null);

      if (!res || !res.ok) {
        res = await fetch("http://localhost:5000/api/v1/orders", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(payload),
        });
      }

      const data = (await res.json()) as ReceiptResponse;

      if (!res.ok || !data.success) {
        throw new Error("Tạo đơn hàng thất bại!");
      }

      setReceiptData(data);
      setCart([]);
      handleSearchCustomerByPhone();
    } catch (err: unknown) {
      const msg = err instanceof Error ? err.message : "Đã có lỗi xảy ra";
      setErrorMessage(msg);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="flex h-screen bg-slate-100 text-slate-800 overflow-hidden font-sans flex-col md:flex-row">
      {/* 1. THANH SIDEBAR */}
      <Sidebar />

      {/* MOBILE TAB SWITCHER */}
      <div className="lg:hidden bg-white border-b border-slate-200 p-2 flex gap-2 font-mono text-xs font-bold pl-16 md:pl-2">
        <button
          onClick={() => setMobileTab("cart")}
          className={`flex-1 py-2 rounded-xl flex items-center justify-center gap-1.5 transition-all ${
            mobileTab === "cart" ? "bg-[#2161D9] text-white shadow-sm" : "bg-slate-100 text-slate-600"
          }`}
        >
          <ShoppingCart className="w-4 h-4" /> Giỏ Hàng ({cart.length})
        </button>
        <button
          onClick={() => setMobileTab("payment")}
          className={`flex-1 py-2 rounded-xl flex items-center justify-center gap-1.5 transition-all ${
            mobileTab === "payment" ? "bg-[#2161D9] text-white shadow-sm" : "bg-slate-100 text-slate-600"
          }`}
        >
          <CreditCard className="w-4 h-4" /> Thanh Toán ({finalAmount.toLocaleString("vi-VN")}đ)
        </button>
      </div>

      {/* 2. CỘT GIỮA: Ô QUÉT MÃ VẠCH & BẢNG GIỎ HÀNG */}
      <div
        className={`flex-1 flex-col p-4 md:p-6 border-r border-slate-200 bg-slate-50 overflow-hidden ${
          mobileTab === "cart" ? "flex" : "hidden lg:flex"
        }`}
      >
        {/* Header POS */}
        <div className="flex items-center justify-between mb-4 md:mb-6 bg-white p-3.5 md:p-4 rounded-2xl shadow-sm border border-slate-200">
          <div>
            <h1 className="text-xl md:text-2xl font-extrabold text-[#2161D9] flex items-center gap-2">
              <ShoppingCart className="w-6 h-6 md:w-7 md:h-7 text-[#2161D9]" /> FASHION POS TERMINAL
            </h1>
            <p className="text-[10px] md:text-xs text-slate-500 mt-0.5">Phần mềm bán hàng quầy - Tích Điểm Khách Hàng SĐT Engine</p>
          </div>
          
          <div className="hidden sm:flex items-center gap-3">
            <span className="bg-blue-50 border border-blue-200 text-[#2161D9] text-xs font-bold px-3 py-1.5 rounded-full font-mono flex items-center gap-1.5">
              <span className="w-2 h-2 rounded-full bg-[#2161D9] animate-pulse"></span> DB PostgreSQL Online
            </span>
          </div>
        </div>

        {/* Form Quét Mã Vạch SKU */}
        <form onSubmit={handleScanSku} className="mb-4 md:mb-6 flex gap-2 md:gap-3">
          <div className="relative flex-1">
            <Search className="absolute left-3.5 top-3.5 text-slate-400 w-4 h-4 md:w-5 md:h-5" />
            <input
              type="text"
              value={skuSearch}
              onChange={(e) => setSkuSearch(e.target.value)}
              placeholder="Quét mã vạch SKU (Ví dụ: SKU-AO-001-XAM-36)..."
              className="w-full bg-white border border-slate-300 focus:border-[#2161D9] focus:ring-2 focus:ring-blue-100 rounded-xl pl-10 md:pl-12 pr-4 py-2.5 md:py-3 text-xs md:text-sm text-slate-900 placeholder-slate-400 outline-none transition-all shadow-sm"
            />
          </div>
          <button
            type="submit"
            disabled={isLoading}
            className="bg-[#2161D9] hover:bg-blue-700 text-white font-bold px-4 md:px-7 py-2.5 md:py-3 rounded-xl text-xs md:text-sm transition-all flex items-center gap-2 shadow-md shadow-blue-500/20 disabled:opacity-50"
          >
            {isLoading ? <RefreshCw className="w-4 h-4 animate-spin" /> : "Tìm SKU"}
          </button>
        </form>

        {errorMessage && (
          <div className="mb-4 p-3 md:p-4 bg-red-50 border border-red-200 text-red-600 rounded-xl text-xs md:text-sm flex items-center gap-2 shadow-sm">
            <AlertCircle className="w-5 h-5 flex-shrink-0" />
            <span className="font-medium">{errorMessage}</span>
          </div>
        )}

        {/* Bảng Danh Sách Sản Phẩm Trong Giỏ */}
        <div className="flex-1 bg-white border border-slate-200 rounded-2xl overflow-hidden flex flex-col shadow-sm">
          <div className="overflow-x-auto overflow-y-auto flex-1">
            <table className="w-full text-left text-sm min-w-[500px]">
              <thead className="bg-[#F0F5FF] text-[#2161D9] font-mono text-xs uppercase border-b border-slate-200">
                <tr>
                  <th className="p-3 md:p-4 font-bold">Sản Phẩm</th>
                  <th className="p-3 md:p-4 font-bold">SKU / Size / Màu</th>
                  <th className="p-3 md:p-4 font-bold">Đơn Giá</th>
                  <th className="p-3 md:p-4 text-center font-bold">Số Lượng</th>
                  <th className="p-3 md:p-4 text-right font-bold">Thành Tiền</th>
                  <th className="p-3 md:p-4 text-center font-bold">Xóa</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {cart.length === 0 ? (
                  <tr>
                    <td colSpan={6} className="text-center py-16 md:py-20 text-slate-400">
                      Chưa có sản phẩm nào trong đơn hàng. Hãy quét mã vạch SKU!
                    </td>
                  </tr>
                ) : (
                  cart.map((item) => (
                    <tr key={item.variantId} className="hover:bg-blue-50/40 transition-colors text-xs md:text-sm">
                      <td className="p-3 md:p-4 font-bold text-slate-900">{item.productName}</td>
                      <td className="p-3 md:p-4 font-mono text-xs text-[#2161D9] font-semibold">
                        {item.sku} <span className="text-slate-300">|</span> {item.size} <span className="text-slate-300">|</span> {item.color}
                      </td>
                      <td className="p-3 md:p-4 font-mono font-medium text-slate-700">{item.price.toLocaleString("vi-VN")}đ</td>
                      <td className="p-3 md:p-4">
                        <div className="flex items-center justify-center gap-1.5 md:gap-2">
                          <button
                            onClick={() => updateQuantity(item.variantId, -1)}
                            className="w-6 h-6 md:w-7 md:h-7 bg-slate-100 hover:bg-slate-200 text-slate-700 rounded-lg flex items-center justify-center transition-colors font-bold"
                          >
                            <Minus className="w-3 h-3 md:w-3.5 md:h-3.5" />
                          </button>
                          <span className="w-6 text-center font-mono font-bold text-slate-900">{item.quantity}</span>
                          <button
                            onClick={() => updateQuantity(item.variantId, 1)}
                            className="w-6 h-6 md:w-7 md:h-7 bg-slate-100 hover:bg-slate-200 text-slate-700 rounded-lg flex items-center justify-center transition-colors font-bold"
                          >
                            <Plus className="w-3 h-3 md:w-3.5 md:h-3.5" />
                          </button>
                        </div>
                      </td>
                      <td className="p-3 md:p-4 font-mono font-extrabold text-right text-emerald-600">
                        {(item.price * item.quantity).toLocaleString("vi-VN")}đ
                      </td>
                      <td className="p-3 md:p-4 text-center">
                        <button
                          onClick={() => removeItem(item.variantId)}
                          className="text-slate-400 hover:text-red-500 p-1 transition-colors"
                        >
                          <Trash2 className="w-4 h-4" />
                        </button>
                      </td>
                    </tr>
                  ))
                )}
              </tbody>
            </table>
          </div>
        </div>
      </div>

      {/* 3. CỘT PHẢI: KHU VỰC TÍCH ĐIỂM SĐT & THANH TOÁN */}
      <div
        className={`w-full lg:w-96 bg-white p-4 md:p-6 flex-col justify-between border-l border-slate-200 shadow-sm overflow-y-auto ${
          mobileTab === "payment" ? "flex" : "hidden lg:flex"
        }`}
      >
        <div>
          {/* TRA CỨU KHÁCH HÀNG THEO SĐT */}
          <div className="mb-6 bg-[#F0F5FF] p-4 rounded-2xl border border-blue-100">
            <label className="text-xs font-mono uppercase text-[#2161D9] font-extrabold mb-2 block flex items-center gap-1.5">
              <UserCheck className="w-4 h-4" /> Khách Hàng Tích Điểm (SĐT)
            </label>
            <form onSubmit={handleSearchCustomerByPhone} className="flex gap-2 mb-3">
              <div className="relative flex-1">
                <Phone className="absolute left-3 top-2.5 text-slate-400 w-3.5 h-3.5" />
                <input
                  type="text"
                  value={phoneSearch}
                  onChange={(e) => setPhoneSearch(e.target.value)}
                  placeholder="Nhập SĐT khách hàng..."
                  className="w-full bg-white border border-slate-300 focus:border-[#2161D9] rounded-xl pl-9 pr-3 py-1.5 text-xs text-slate-900 font-mono font-bold outline-none"
                />
              </div>
              <button
                type="submit"
                disabled={isSearchingCustomer}
                className="bg-[#2161D9] hover:bg-blue-700 text-white font-bold px-3 py-1.5 rounded-xl text-xs transition-all"
              >
                {isSearchingCustomer ? <RefreshCw className="w-3.5 h-3.5 animate-spin" /> : "Tìm"}
              </button>
            </form>

            {/* HIỂN THỊ KẾT QUẢ TÌM KIẾM SĐT KHÁCH HÀNG */}
            {selectedCustomer ? (
              <div className="bg-white p-3 rounded-xl border border-blue-200 text-xs space-y-1">
                <div className="flex justify-between items-center">
                  <span className="font-bold text-slate-900">{selectedCustomer.fullName}</span>
                  <span className="bg-slate-900 text-amber-400 font-extrabold px-2 py-0.5 rounded-md text-[10px] font-mono">
                    {selectedCustomer.membershipTier}
                  </span>
                </div>
                <div className="flex justify-between text-slate-600 font-mono text-[11px]">
                  <span>Điểm hiện có: <strong className="text-[#2161D9]">{selectedCustomer.loyaltyPoints} điểm</strong></span>
                  <span className="text-emerald-600 font-bold">+{estimatedEarnedPoints} điểm đơn này</span>
                </div>
              </div>
            ) : showRegisterPrompt ? (
              <div className="bg-amber-50 p-3 rounded-xl border border-amber-200 text-xs space-y-2">
                <p className="text-amber-800 font-medium text-[11px]">
                  SĐT <strong>{phoneSearch}</strong> chưa đăng ký thành viên!
                </p>
                <button
                  type="button"
                  onClick={handleOpenRegisterModal}
                  className="w-full bg-[#2161D9] hover:bg-blue-700 text-white font-bold py-1.5 rounded-lg text-xs flex items-center justify-center gap-1 shadow-sm transition-all"
                >
                  <UserPlus className="w-3.5 h-3.5" /> + Đăng Ký Thành Viên Mới
                </button>
              </div>
            ) : (
              <p className="text-[11px] text-slate-400 font-mono italic text-center">
                Khách mới / Chưa tích điểm
              </p>
            )}
          </div>

          <h2 className="text-base md:text-lg font-bold text-slate-900 mb-4 md:mb-6 flex items-center gap-2 border-b border-slate-100 pb-3 md:pb-4">
            <CreditCard className="w-5 h-5 text-[#2161D9]" /> TỔNG KẾT THANH TOÁN
          </h2>

          <div className="space-y-3 md:space-y-4 text-xs md:text-sm font-sans mb-6">
            <div className="flex justify-between text-slate-600">
              <span>Tổng tiền hàng:</span>
              <span className="font-mono text-slate-900 font-bold">{totalItemsAmount.toLocaleString("vi-VN")}đ</span>
            </div>

            <div className="flex justify-between text-slate-600 items-center">
              <span>Giảm giá (đ):</span>
              <input
                type="number"
                value={discountValue}
                onChange={(e) => setDiscountValue(Number(e.target.value))}
                className="w-24 md:w-28 bg-slate-50 border border-slate-300 text-right px-2.5 py-1 rounded-lg text-xs md:text-sm text-[#2161D9] font-mono outline-none focus:border-[#2161D9]"
              />
            </div>

            <div className="border-t border-slate-100 pt-3 md:pt-4 flex justify-between text-sm md:text-base font-bold">
              <span className="text-slate-800">KHÁCH CẦN TRẢ:</span>
              <span className="text-[#2161D9] font-mono text-lg md:text-xl">{finalAmount.toLocaleString("vi-VN")}đ</span>
            </div>
          </div>

          {/* Phương Thức Thanh Toán */}
          <div className="mb-6">
            <label className="text-[10px] md:text-xs font-mono uppercase text-slate-500 font-bold mb-2 block">Phương Thức Thanh Toán</label>
            <div className="grid grid-cols-2 gap-2">
              {["CASH", "VNPAY", "MOMO", "BANK_TRANSFER"].map((method) => (
                <button
                  key={method}
                  type="button"
                  onClick={() => setPaymentMethod(method)}
                  className={`py-2 px-2.5 rounded-xl text-[11px] md:text-xs font-bold font-mono transition-all border ${
                    paymentMethod === method
                      ? "bg-[#2161D9] border-[#2161D9] text-white shadow-sm"
                      : "bg-slate-50 border-slate-200 text-slate-600 hover:border-slate-300"
                  }`}
                >
                  {method === "CASH" ? "Tiền Mặt" : method}
                </button>
              ))}
            </div>
          </div>

          {/* Tiền Khách Đưa & Tiền Thối */}
          <div className="space-y-3 md:space-y-4 mb-6">
            <div>
              <label className="text-[10px] md:text-xs font-mono uppercase text-slate-500 font-bold mb-1 block">Tiền Khách Đưa (đ)</label>
              <input
                type="number"
                value={paidAmount}
                onChange={(e) => setPaidAmount(Number(e.target.value))}
                className="w-full bg-slate-50 border border-slate-300 text-right px-4 py-2 md:py-2.5 rounded-xl text-base md:text-lg text-emerald-600 font-mono outline-none font-extrabold focus:border-emerald-500"
              />
            </div>

            <div className="flex justify-between items-center bg-[#F0F5FF] p-3 md:p-3.5 rounded-xl border border-blue-100">
              <span className="text-[10px] md:text-xs font-mono uppercase text-[#2161D9] font-bold">Tiền Thối Lại:</span>
              <span className="font-mono text-base md:text-lg font-bold text-amber-600">{changeAmount.toLocaleString("vi-VN")}đ</span>
            </div>
          </div>
        </div>

        {/* Nút Bấm Thanh Toán POS */}
        <button
          onClick={handleCheckout}
          disabled={isLoading || cart.length === 0}
          className="w-full bg-[#2161D9] hover:bg-blue-700 text-white font-bold py-3.5 md:py-4 rounded-xl text-sm md:text-base shadow-lg shadow-blue-500/20 transition-all flex items-center justify-center gap-2 disabled:opacity-40 disabled:cursor-not-allowed mt-4"
        >
          {isLoading ? <RefreshCw className="w-5 h-5 animate-spin" /> : "HOÀN TẤT THANH TOÁN (F9)"}
        </button>
      </div>

      {/* MODAL ĐĂNG KÝ THÀNH VIÊN MỚI NHANH TẠI QUẦY */}
      {isCustomerModalOpen && (
        <div className="fixed inset-0 bg-slate-900/60 backdrop-blur-sm flex items-center justify-center z-50 p-4">
          <div className="bg-white border border-slate-200 rounded-3xl p-6 md:p-8 max-w-md w-full shadow-2xl relative">
            <div className="flex items-center justify-between pb-4 border-b border-slate-100 mb-6">
              <h3 className="text-lg font-bold text-slate-900 flex items-center gap-2">
                <UserPlus className="w-5 h-5 text-[#2161D9]" /> ĐĂNG KÝ THÀNH VIÊN MỚI (.NET 8)
              </h3>
              <button onClick={() => setIsCustomerModalOpen(false)} className="text-slate-400 hover:text-slate-600">
                <X className="w-5 h-5" />
              </button>
            </div>

            {customerModalError && (
              <div className="mb-4 p-3 bg-red-50 border border-red-200 text-red-600 rounded-xl text-xs flex items-center gap-2">
                <AlertCircle className="w-4 h-4 flex-shrink-0" />
                <span>{customerModalError}</span>
              </div>
            )}

            <form onSubmit={handleRegisterCustomer} className="space-y-4">
              <div>
                <label className="text-xs font-mono uppercase text-slate-500 font-bold mb-1 block">Họ Và Tên Khách Hàng</label>
                <input
                  type="text"
                  value={newCustName}
                  onChange={(e) => setNewCustName(e.target.value)}
                  placeholder="Ví dụ: Nguyễn Văn Khách..."
                  required
                  className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl px-4 py-2.5 text-sm text-slate-900 outline-none"
                />
              </div>

              <div>
                <label className="text-xs font-mono uppercase text-slate-500 font-bold mb-1 block">Số Điện Thoại</label>
                <input
                  type="text"
                  value={newCustPhone}
                  onChange={(e) => setNewCustPhone(e.target.value)}
                  required
                  className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl px-4 py-2.5 text-sm text-[#2161D9] font-mono font-bold outline-none"
                />
              </div>

              <button
                type="submit"
                disabled={isCreatingCustomer}
                className="w-full bg-[#2161D9] hover:bg-blue-700 text-white font-bold py-3.5 rounded-xl text-sm shadow-lg shadow-blue-500/20 transition-all flex items-center justify-center gap-2 mt-6 disabled:opacity-50"
              >
                {isCreatingCustomer ? <RefreshCw className="w-4 h-4 animate-spin" /> : "XÁC NHẬN ĐĂNG KÝ VÀ TÍCH ĐIỂM"}
              </button>
            </form>
          </div>
        </div>
      )}

      {/* MODAL HÓA ĐƠN RECEIPT KHI THANH TOÁN THÀNH CÔNG */}
      {receiptData && (
        <div className="fixed inset-0 bg-slate-900/60 backdrop-blur-sm flex items-center justify-center z-50 p-4">
          <div className="bg-white border border-slate-200 rounded-3xl p-6 md:p-8 max-w-md w-full text-center shadow-2xl">
            <div className="w-14 h-14 md:w-16 md:h-16 bg-emerald-50 border border-emerald-200 text-emerald-600 rounded-full flex items-center justify-center mx-auto mb-4">
              <CheckCircle2 className="w-8 h-8 md:w-10 md:h-10" />
            </div>
            <h3 className="text-lg md:text-xl font-bold text-slate-900 mb-1">Thanh Toán Thành Công!</h3>
            <p className="text-xs text-slate-500 mb-4 md:mb-6 font-mono">Mã Hóa Đơn: {receiptData.orderCode}</p>

            <div className="bg-slate-50 p-4 rounded-2xl border border-slate-200 text-xs md:text-sm space-y-2 mb-6 font-mono text-left">
              <div className="flex justify-between text-slate-600">
                <span>Tổng tiền hàng:</span>
                <span className="text-slate-900 font-bold">{receiptData.totalItemsAmount?.toLocaleString("vi-VN")}đ</span>
              </div>
              <div className="flex justify-between text-slate-700 font-bold border-t border-slate-200 pt-2">
                <span className="text-slate-800">Khách Cần Trả:</span>
                <span className="text-[#2161D9]">{receiptData.finalAmount?.toLocaleString("vi-VN")}đ</span>
              </div>
              <div className="flex justify-between text-slate-600">
                <span>Khách Đã Trả:</span>
                <span className="text-slate-900 font-bold">{receiptData.paidAmount?.toLocaleString("vi-VN")}đ</span>
              </div>
              <div className="flex justify-between text-amber-600 font-bold">
                <span>Tiền Thối Lại:</span>
                <span>{receiptData.changeAmount?.toLocaleString("vi-VN")}đ</span>
              </div>
              <div className="flex justify-between text-[#2161D9] border-t border-slate-200 pt-2 font-bold">
                <span>Điểm Tích Lũy Cộng:</span>
                <span>+{receiptData.earnedPoints} điểm</span>
              </div>
            </div>

            <button
              onClick={() => setReceiptData(null)}
              className="w-full bg-[#2161D9] hover:bg-blue-700 text-white font-bold py-3 rounded-xl transition-all shadow-md shadow-blue-500/20 text-sm"
            >
              In Hóa Đơn & Đóng
            </button>
          </div>
        </div>
      )}
    </div>
  );
}
