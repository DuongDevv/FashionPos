"use client";

import React, { useEffect, useState } from "react";
import Sidebar from "@/components/Sidebar";
import { Package, Plus, Search, RefreshCw, CheckCircle, XCircle, X, AlertCircle } from "lucide-react";

interface Product {
  id: number;
  name: string;
  slug: string;
  basePrice: number;
  isActive: boolean;
}

export default function ProductsPage() {
  const [products, setProducts] = useState<Product[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [search, setSearch] = useState<string>("");

  // Modal State
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
  const [isSubmitting, setIsSubmitting] = useState<boolean>(false);
  const [modalError, setModalError] = useState<string | null>(null);
  const [successMessage, setSuccessMessage] = useState<string | null>(null);

  // Form Fields
  const [name, setName] = useState("");
  const [basePrice, setBasePrice] = useState<number>(250000);
  const [sku, setSku] = useState("");
  const [size, setSize] = useState("L");
  const [color, setColor] = useState("Đen");
  const [stockQuantity, setStockQuantity] = useState<number>(20);

  const API_BASE_URL = "http://localhost:5000/api/v1";

  const fetchProducts = () => {
    setIsLoading(true);
    fetch(`${API_BASE_URL}/products`)
      .then((res) => res.json())
      .then((data) => {
        if (data.success) {
          setProducts(data.data);
        }
      })
      .catch((err) => console.error(err))
      .finally(() => setIsLoading(false));
  };

  useEffect(() => {
    fetchProducts();
  }, []);

  const handleOpenModal = () => {
    const autoSku = `SKU-AO-${Math.floor(100 + Math.random() * 900)}-BLK-${size}`;
    setSku(autoSku);
    setModalError(null);
    setIsModalOpen(true);
  };

  const handleCreateProduct = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!name.trim() || !sku.trim()) {
      setModalError("Vui lòng điền đầy đủ tên sản phẩm và mã SKU!");
      return;
    }

    setIsSubmitting(true);
    setModalError(null);

    const payload = {
      name: name.trim(),
      categoryId: 1,
      basePrice: Number(basePrice),
      sku: sku.trim().toUpperCase(),
      size: size,
      color: color,
      stockQuantity: Number(stockQuantity),
    };

    try {
      const res = await fetch(`${API_BASE_URL}/products`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload),
      });

      const data = await res.json();

      if (!res.ok || !data.success) {
        throw new Error(data.message || "Tạo sản phẩm mới thất bại!");
      }

      setSuccessMessage(`Đã thêm sản phẩm "${name}" thành công!`);
      setIsModalOpen(false);
      setName("");
      fetchProducts();

      setTimeout(() => setSuccessMessage(null), 4000);
    } catch (err: unknown) {
      const msg = err instanceof Error ? err.message : "Đã có lỗi xảy ra!";
      setModalError(msg);
    } finally {
      setIsSubmitting(false);
    }
  };

  const filteredProducts = products.filter((p) =>
    p.name.toLowerCase().includes(search.toLowerCase()) || p.slug.toLowerCase().includes(search.toLowerCase())
  );

  return (
    <div className="flex h-screen bg-slate-100 text-slate-800 font-sans overflow-hidden">
      <Sidebar />

      <main className="flex-1 overflow-y-auto p-4 md:p-8">
        {/* Header */}
        <div className="flex items-center justify-between mb-8">
          <div>
            <h1 className="text-xl md:text-2xl font-extrabold text-slate-900 flex items-center gap-2">
              <Package className="w-6 h-6 md:w-7 md:h-7 text-[#2161D9]" /> QUẢN LÝ SẢN PHẨM & KHO HÀNG
            </h1>
            <p className="text-xs text-slate-500 mt-1">Danh mục sản phẩm, biến thể SKU và tồn kho PostgreSQL</p>
          </div>
          <button
            onClick={handleOpenModal}
            className="bg-[#2161D9] hover:bg-blue-700 text-white font-bold px-5 py-2.5 rounded-xl text-xs flex items-center gap-2 shadow-md shadow-blue-500/20 transition-all"
          >
            <Plus className="w-4 h-4" /> Thêm Sản Phẩm Mới
          </button>
        </div>

        {successMessage && (
          <div className="mb-6 p-4 bg-emerald-50 border border-emerald-200 text-emerald-700 rounded-xl text-sm flex items-center gap-2 shadow-sm font-semibold">
            <CheckCircle className="w-5 h-5 text-emerald-600" />
            <span>{successMessage}</span>
          </div>
        )}

        {/* Form Tìm Kiếm */}
        <div className="bg-white p-4 rounded-2xl border border-slate-200 shadow-sm mb-6 flex justify-between items-center">
          <div className="relative w-72 md:w-96">
            <Search className="absolute left-3.5 top-3 text-slate-400 w-4 h-4" />
            <input
              type="text"
              value={search}
              onChange={(e) => setSearch(e.target.value)}
              placeholder="Tìm kiếm sản phẩm theo tên hoặc mã slug..."
              className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl pl-10 pr-4 py-2 text-xs text-slate-900 placeholder-slate-400 outline-none transition-all"
            />
          </div>
          <span className="text-xs font-mono text-slate-500">Hiển thị {filteredProducts.length} sản phẩm</span>
        </div>

        {/* Bảng Danh Sách Sản Phẩm */}
        <div className="bg-white border border-slate-200 rounded-2xl overflow-hidden shadow-sm">
          {isLoading ? (
            <div className="p-12 text-center text-slate-400 flex items-center justify-center gap-2 font-mono text-xs">
              <RefreshCw className="w-5 h-5 animate-spin text-[#2161D9]" /> Đang tải danh sách từ PostgreSQL...
            </div>
          ) : (
            <table className="w-full text-left text-sm">
              <thead className="bg-[#F0F5FF] text-[#2161D9] font-mono text-xs uppercase border-b border-slate-200">
                <tr>
                  <th className="p-4 font-bold">ID</th>
                  <th className="p-4 font-bold">Tên Sản Phẩm</th>
                  <th className="p-4 font-bold">Mã Slug</th>
                  <th className="p-4 font-bold text-right">Giá Cơ Bản</th>
                  <th className="p-4 text-center font-bold">Trạng Thái</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {filteredProducts.map((p) => (
                  <tr key={p.id} className="hover:bg-blue-50/40 transition-colors">
                    <td className="p-4 font-mono font-bold text-slate-400">#{p.id}</td>
                    <td className="p-4 font-bold text-slate-900">{p.name}</td>
                    <td className="p-4 font-mono text-xs text-[#2161D9]">{p.slug}</td>
                    <td className="p-4 font-mono font-extrabold text-right text-emerald-600">
                      {p.basePrice.toLocaleString("vi-VN")}đ
                    </td>
                    <td className="p-4 text-center">
                      {p.isActive ? (
                        <span className="inline-flex items-center gap-1 text-[11px] font-bold text-emerald-700 bg-emerald-50 px-3 py-1 rounded-full border border-emerald-200">
                          <CheckCircle className="w-3.5 h-3.5" /> Đang Kinh Doanh
                        </span>
                      ) : (
                        <span className="inline-flex items-center gap-1 text-[11px] font-bold text-red-700 bg-red-50 px-3 py-1 rounded-full border border-red-200">
                          <XCircle className="w-3.5 h-3.5" /> Ngừng Bán
                        </span>
                      )}
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </div>
      </main>

      {/* MODAL THÊM SẢN PHẨM MỚI */}
      {isModalOpen && (
        <div className="fixed inset-0 bg-slate-900/60 backdrop-blur-sm flex items-center justify-center z-50 p-4">
          <div className="bg-white border border-slate-200 rounded-3xl p-6 md:p-8 max-w-lg w-full shadow-2xl relative">
            <div className="flex items-center justify-between pb-4 border-b border-slate-100 mb-6">
              <h3 className="text-lg font-bold text-slate-900 flex items-center gap-2">
                <Package className="w-5 h-5 text-[#2161D9]" /> THÊM SẢN PHẨM MỚI (POSTGRESQL)
              </h3>
              <button onClick={() => setIsModalOpen(false)} className="text-slate-400 hover:text-slate-600">
                <X className="w-5 h-5" />
              </button>
            </div>

            {modalError && (
              <div className="mb-4 p-3 bg-red-50 border border-red-200 text-red-600 rounded-xl text-xs flex items-center gap-2">
                <AlertCircle className="w-4 h-4 flex-shrink-0" />
                <span>{modalError}</span>
              </div>
            )}

            <form onSubmit={handleCreateProduct} className="space-y-4">
              <div>
                <label className="text-xs font-mono uppercase text-slate-500 font-bold mb-1 block">Tên Sản Phẩm</label>
                <input
                  type="text"
                  value={name}
                  onChange={(e) => setName(e.target.value)}
                  placeholder="Ví dụ: Áo Polo NQD Premium..."
                  required
                  className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl px-4 py-2.5 text-sm text-slate-900 outline-none"
                />
              </div>

              <div className="grid grid-cols-2 gap-3">
                <div>
                  <label className="text-xs font-mono uppercase text-slate-500 font-bold mb-1 block">Giá Bán (đ)</label>
                  <input
                    type="number"
                    value={basePrice}
                    onChange={(e) => setBasePrice(Number(e.target.value))}
                    required
                    className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl px-4 py-2.5 text-sm text-[#2161D9] font-mono font-bold outline-none"
                  />
                </div>
                <div>
                  <label className="text-xs font-mono uppercase text-slate-500 font-bold mb-1 block">Mã Vạch SKU</label>
                  <input
                    type="text"
                    value={sku}
                    onChange={(e) => setSku(e.target.value)}
                    required
                    className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl px-4 py-2.5 text-sm text-slate-900 font-mono font-bold outline-none uppercase"
                  />
                </div>
              </div>

              <div className="grid grid-cols-3 gap-3">
                <div>
                  <label className="text-xs font-mono uppercase text-slate-500 font-bold mb-1 block">Size</label>
                  <select
                    value={size}
                    onChange={(e) => setSize(e.target.value)}
                    className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl px-3 py-2.5 text-xs text-slate-900 font-bold outline-none"
                  >
                    <option value="S">Size S</option>
                    <option value="M">Size M</option>
                    <option value="L">Size L</option>
                    <option value="XL">Size XL</option>
                    <option value="36">Size 36</option>
                    <option value="38">Size 38</option>
                  </select>
                </div>
                <div>
                  <label className="text-xs font-mono uppercase text-slate-500 font-bold mb-1 block">Màu Sắc</label>
                  <input
                    type="text"
                    value={color}
                    onChange={(e) => setColor(e.target.value)}
                    required
                    className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl px-3 py-2.5 text-xs text-slate-900 font-bold outline-none"
                  />
                </div>
                <div>
                  <label className="text-xs font-mono uppercase text-slate-500 font-bold mb-1 block">Tồn Kho Ban Đầu</label>
                  <input
                    type="number"
                    value={stockQuantity}
                    onChange={(e) => setStockQuantity(Number(e.target.value))}
                    required
                    className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl px-3 py-2.5 text-xs text-emerald-600 font-mono font-bold outline-none"
                  />
                </div>
              </div>

              <button
                type="submit"
                disabled={isSubmitting}
                className="w-full bg-[#2161D9] hover:bg-blue-700 text-white font-bold py-3.5 rounded-xl text-sm shadow-lg shadow-blue-500/20 transition-all flex items-center justify-center gap-2 mt-6 disabled:opacity-50"
              >
                {isSubmitting ? <RefreshCw className="w-4 h-4 animate-spin" /> : "LƯU SẢN PHẨM VÀO POSTGRESQL"}
              </button>
            </form>
          </div>
        </div>
      )}
    </div>
  );
}
