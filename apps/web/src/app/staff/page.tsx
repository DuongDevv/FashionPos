"use client";

import React, { useEffect, useState } from "react";
import Sidebar from "@/components/Sidebar";
import { ShieldCheck, UserPlus, Search, RefreshCw, CheckCircle, X, AlertCircle, User } from "lucide-react";

interface Employee {
  id: number;
  fullName: string;
  username: string;
  role: string;
  status: string;
}

export default function StaffPage() {
  const [employees, setEmployees] = useState<Employee[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [search, setSearch] = useState<string>("");
  const [pageError, setPageError] = useState<string | null>(null);

  // Modal State
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
  const [isSubmitting, setIsSubmitting] = useState<boolean>(false);
  const [modalError, setModalError] = useState<string | null>(null);
  const [successMessage, setSuccessMessage] = useState<string | null>(null);

  // Form Fields
  const [fullName, setFullName] = useState("");
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("123456");
  const [role, setRole] = useState("CASHIER");

  const getApiUrl = (endpoint: string) => {
    if (typeof window !== "undefined") {
      return `/api/v1${endpoint}`;
    }
    return `http://localhost:5000/api/v1${endpoint}`;
  };

  const fetchEmployees = async () => {
    setIsLoading(true);
    setPageError(null);

    try {
      const primaryUrl = getApiUrl("/employees");
      let res = await fetch(primaryUrl).catch(() => null);

      if (!res || !res.ok) {
        // Fallback direct URL
        res = await fetch("http://localhost:5000/api/v1/employees");
      }

      if (!res.ok) {
        throw new Error("Không thể kết nối đến Server Backend .NET 8!");
      }

      const data = await res.json();
      if (data.success) {
        setEmployees(data.data);
      } else {
        throw new Error(data.message || "Tải danh sách nhân viên thất bại!");
      }
    } catch (err: unknown) {
      const msg = err instanceof Error ? err.message : "Lỗi kết nối Backend API!";
      setPageError(msg);
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    fetchEmployees();
  }, []);

  const handleOpenModal = () => {
    setFullName("");
    setUsername("");
    setPassword("123456");
    setRole("CASHIER");
    setModalError(null);
    setIsModalOpen(true);
  };

  const handleCreateEmployee = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!fullName.trim() || !username.trim() || !password.trim()) {
      setModalError("Vui lòng điền đầy đủ họ tên, tên đăng nhập và mật khẩu!");
      return;
    }

    setIsSubmitting(true);
    setModalError(null);

    const payload = {
      fullName: fullName.trim(),
      username: username.trim(),
      password: password.trim(),
      role: role,
    };

    try {
      let res = await fetch(getApiUrl("/employees"), {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload),
      }).catch(() => null);

      if (!res || !res.ok) {
        res = await fetch("http://localhost:5000/api/v1/employees", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(payload),
        });
      }

      const data = await res.json();

      if (!res.ok || !data.success) {
        throw new Error(data.message || "Thêm nhân viên mới thất bại!");
      }

      setSuccessMessage(`Đã thêm nhân viên "${fullName}" (${role}) thành công!`);
      setIsModalOpen(false);
      fetchEmployees();

      setTimeout(() => setSuccessMessage(null), 4000);
    } catch (err: unknown) {
      const msg = err instanceof Error ? err.message : "Đã có lỗi xảy ra!";
      setModalError(msg);
    } finally {
      setIsSubmitting(false);
    }
  };

  const filteredEmployees = employees.filter(
    (e) => e.fullName.toLowerCase().includes(search.toLowerCase()) || e.username.toLowerCase().includes(search.toLowerCase())
  );

  const getRoleBadge = (roleName: string) => {
    switch (roleName) {
      case "SUPER_MANAGER":
        return <span className="bg-[#2161D9] text-white font-extrabold px-3 py-1 rounded-full text-xs shadow-sm">SUPER MANAGER</span>;
      case "STORE_MANAGER":
        return <span className="bg-purple-100 text-purple-800 font-bold px-3 py-1 rounded-full text-xs border border-purple-200">QUẢN LÝ CỬA HÀNG</span>;
      case "WAREHOUSE_STAFF":
        return <span className="bg-amber-100 text-amber-800 font-bold px-3 py-1 rounded-full text-xs border border-[#2161D9]">NHÂN VIÊN KHO</span>;
      default:
        return <span className="bg-emerald-100 text-emerald-800 font-bold px-3 py-1 rounded-full text-xs border border-emerald-200">THU NGÂN POS</span>;
    }
  };

  return (
    <div className="flex h-screen bg-slate-100 text-slate-800 font-sans overflow-hidden">
      <Sidebar />

      <main className="flex-1 overflow-y-auto p-4 md:p-8">
        {/* Header */}
        <div className="flex items-center justify-between mb-8">
          <div>
            <h1 className="text-xl md:text-2xl font-extrabold text-slate-900 flex items-center gap-2">
              <ShieldCheck className="w-6 h-6 md:w-7 md:h-7 text-[#2161D9]" /> QUẢN LÝ NHÂN VIÊN & PHÂN QUYỀN
            </h1>
            <p className="text-xs text-slate-500 mt-1">Danh sách tài khoản nhân viên, mã hóa mật khẩu BCrypt & phân quyền PostgreSQL</p>
          </div>
          <button
            onClick={handleOpenModal}
            className="bg-[#2161D9] hover:bg-blue-700 text-white font-bold px-5 py-2.5 rounded-xl text-xs flex items-center gap-2 shadow-md shadow-blue-500/20 transition-all"
          >
            <UserPlus className="w-4 h-4" /> Thêm Nhân Viên Mới
          </button>
        </div>

        {pageError && (
          <div className="mb-6 p-4 bg-amber-50 border border-amber-200 text-amber-800 rounded-xl text-xs flex items-center justify-between shadow-sm">
            <div className="flex items-center gap-2 font-semibold">
              <AlertCircle className="w-4 h-4 text-amber-600 flex-shrink-0" />
              <span>{pageError} - Hãy đảm bảo Server .NET 8 (Port 5000) đang chạy.</span>
            </div>
            <button
              onClick={fetchEmployees}
              className="bg-amber-600 text-white font-bold px-3 py-1 rounded-lg text-xs hover:bg-amber-700"
            >
              Thử lại
            </button>
          </div>
        )}

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
              placeholder="Tìm kiếm nhân viên theo tên hoặc tên đăng nhập..."
              className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl pl-10 pr-4 py-2 text-xs text-slate-900 placeholder-slate-400 outline-none transition-all"
            />
          </div>
          <span className="text-xs font-mono text-slate-500">Tổng số: {filteredEmployees.length} nhân viên</span>
        </div>

        {/* Bảng Danh Sách Nhân Viên */}
        <div className="bg-white border border-slate-200 rounded-2xl overflow-hidden shadow-sm">
          {isLoading ? (
            <div className="p-12 text-center text-slate-400 flex items-center justify-center gap-2 font-mono text-xs">
              <RefreshCw className="w-5 h-5 animate-spin text-[#2161D9]" /> Đang tải danh sách nhân viên từ PostgreSQL...
            </div>
          ) : (
            <table className="w-full text-left text-sm">
              <thead className="bg-[#F0F5FF] text-[#2161D9] font-mono text-xs uppercase border-b border-slate-200">
                <tr>
                  <th className="p-4 font-bold">ID</th>
                  <th className="p-4 font-bold">Họ & Tên</th>
                  <th className="p-4 font-bold">Tên Đăng Nhập</th>
                  <th className="p-4 text-center font-bold">Chức Vụ / Quyền</th>
                  <th className="p-4 text-center font-bold">Trạng Thái</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {filteredEmployees.map((e) => (
                  <tr key={e.id} className="hover:bg-blue-50/40 transition-colors">
                    <td className="p-4 font-mono font-bold text-slate-400">#{e.id}</td>
                    <td className="p-4 font-bold text-slate-900 flex items-center gap-3">
                      <div className="w-8 h-8 rounded-full bg-blue-100 text-[#2161D9] font-bold text-xs flex items-center justify-center">
                        <User className="w-4 h-4" />
                      </div>
                      <span>{e.fullName}</span>
                    </td>
                    <td className="p-4 font-mono text-xs font-bold text-[#2161D9]">{e.username}</td>
                    <td className="p-4 text-center">{getRoleBadge(e.role)}</td>
                    <td className="p-4 text-center">
                      <span className="inline-flex items-center gap-1 text-[11px] font-bold text-emerald-700 bg-emerald-50 px-3 py-1 rounded-full border border-emerald-200">
                        <CheckCircle className="w-3.5 h-3.5" /> {e.status}
                      </span>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </div>
      </main>

      {/* MODAL THÊM NHÂN VIÊN MỚI */}
      {isModalOpen && (
        <div className="fixed inset-0 bg-slate-900/60 backdrop-blur-sm flex items-center justify-center z-50 p-4">
          <div className="bg-white border border-slate-200 rounded-3xl p-6 md:p-8 max-w-md w-full shadow-2xl relative">
            <div className="flex items-center justify-between pb-4 border-b border-slate-100 mb-6">
              <h3 className="text-lg font-bold text-slate-900 flex items-center gap-2">
                <UserPlus className="w-5 h-5 text-[#2161D9]" /> THÊM NHÂN VIÊN MỚI (.NET 8 API)
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

            <form onSubmit={handleCreateEmployee} className="space-y-4">
              <div>
                <label className="text-xs font-mono uppercase text-slate-500 font-bold mb-1 block">Họ Và Tên Nhân Viên</label>
                <input
                  type="text"
                  value={fullName}
                  onChange={(e) => setFullName(e.target.value)}
                  placeholder="Ví dụ: Trần Thị B..."
                  required
                  className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl px-4 py-2.5 text-sm text-slate-900 outline-none"
                />
              </div>

              <div>
                <label className="text-xs font-mono uppercase text-slate-500 font-bold mb-1 block">Tên Đăng Nhập (Username)</label>
                <input
                  type="text"
                  value={username}
                  onChange={(e) => setUsername(e.target.value)}
                  placeholder="Ví dụ: thuNgan01..."
                  required
                  className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl px-4 py-2.5 text-sm text-[#2161D9] font-mono font-bold outline-none"
                />
              </div>

              <div>
                <label className="text-xs font-mono uppercase text-slate-500 font-bold mb-1 block">Mật Khẩu</label>
                <input
                  type="password"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                  placeholder="Tối thiểu 6 ký tự..."
                  required
                  className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl px-4 py-2.5 text-sm text-slate-900 font-mono outline-none"
                />
              </div>

              <div>
                <label className="text-xs font-mono uppercase text-slate-500 font-bold mb-1 block">Chức Vụ / Quyền Hạn</label>
                <select
                  value={role}
                  onChange={(e) => setRole(e.target.value)}
                  className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl px-4 py-2.5 text-xs text-slate-900 font-bold outline-none"
                >
                  <option value="CASHIER">Thu Ngân POS (CASHIER)</option>
                  <option value="STORE_MANAGER">Quản Lý Cửa Hàng (STORE_MANAGER)</option>
                  <option value="WAREHOUSE_STAFF">Nhân Viên Kho (WAREHOUSE_STAFF)</option>
                  <option value="SUPER_MANAGER">Super Manager (SUPER_MANAGER)</option>
                </select>
              </div>

              <button
                type="submit"
                disabled={isSubmitting}
                className="w-full bg-[#2161D9] hover:bg-blue-700 text-white font-bold py-3.5 rounded-xl text-sm shadow-lg shadow-blue-500/20 transition-all flex items-center justify-center gap-2 mt-6 disabled:opacity-50"
              >
                {isSubmitting ? <RefreshCw className="w-4 h-4 animate-spin" /> : "LƯU NHÂN VIÊN VÀO POSTGRESQL"}
              </button>
            </form>
          </div>
        </div>
      )}
    </div>
  );
}
