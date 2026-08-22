"use client";

import React, { useState } from "react";
import { useRouter } from "next/navigation";
import { Lock, User, ShoppingCart, RefreshCw, AlertCircle, CheckCircle2 } from "lucide-react";

export default function LoginPage() {
  const router = useRouter();
  const [username, setUsername] = useState("superManager");
  const [password, setPassword] = useState("123456");
  const [isLoading, setIsLoading] = useState(false);
  const [errorMessage, setErrorMessage] = useState<string | null>(null);

  const API_BASE_URL = "http://localhost:5000/api/v1";

  const handleLogin = async (e: React.FormEvent) => {
    e.preventDefault();
    setIsLoading(true);
    setErrorMessage(null);

    try {
      const res = await fetch(`${API_BASE_URL}/auth/login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ username, password }),
      });

      const data = await res.json();

      if (!res.ok || !data.success) {
        throw new Error(data.message || "Tên đăng nhập hoặc mật khẩu không đúng!");
      }

      // Lưu Token & Thông tin vào LocalStorage
      localStorage.setItem("pos_token", data.data.token);
      localStorage.setItem("pos_user", JSON.stringify(data.data));

      // Chuyển hướng sang POS
      router.push("/pos");
    } catch (err: unknown) {
      const msg = err instanceof Error ? err.message : "Đăng nhập thất bại!";
      setErrorMessage(msg);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="min-h-screen bg-slate-100 flex items-center justify-center p-4 font-sans">
      <div className="bg-white border border-slate-200 rounded-3xl p-8 max-w-md w-full shadow-xl">
        {/* Brand Header */}
        <div className="text-center mb-8">
          <div className="w-16 h-16 rounded-2xl bg-[#2161D9] flex items-center justify-center text-white font-extrabold text-2xl mx-auto mb-4 shadow-lg shadow-blue-500/20">
            <ShoppingCart className="w-8 h-8" />
          </div>
          <h1 className="text-2xl font-extrabold text-slate-900">NQD FASHION POS</h1>
          <p className="text-xs text-slate-500 mt-1">Đăng nhập hệ thống quản lý bán hàng Enterprise</p>
        </div>

        {errorMessage && (
          <div className="mb-6 p-4 bg-red-50 border border-red-200 text-red-600 rounded-xl text-xs flex items-center gap-2 font-semibold">
            <AlertCircle className="w-4 h-4 flex-shrink-0" />
            <span>{errorMessage}</span>
          </div>
        )}

        {/* Form Đăng Nhập */}
        <form onSubmit={handleLogin} className="space-y-4">
          <div>
            <label className="text-xs font-mono uppercase text-slate-500 font-bold mb-1 block">Tên Đăng Nhập</label>
            <div className="relative">
              <User className="absolute left-3.5 top-3 text-slate-400 w-4 h-4" />
              <input
                type="text"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                placeholder="Nhập tên đăng nhập..."
                required
                className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl pl-10 pr-4 py-2.5 text-sm text-slate-900 outline-none transition-all font-sans"
              />
            </div>
          </div>

          <div>
            <label className="text-xs font-mono uppercase text-slate-500 font-bold mb-1 block">Mật Khẩu</label>
            <div className="relative">
              <Lock className="absolute left-3.5 top-3 text-slate-400 w-4 h-4" />
              <input
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                placeholder="Nhập mật khẩu..."
                required
                className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl pl-10 pr-4 py-2.5 text-sm text-slate-900 outline-none transition-all font-sans"
              />
            </div>
          </div>

          <button
            type="submit"
            disabled={isLoading}
            className="w-full bg-[#2161D9] hover:bg-blue-700 text-white font-bold py-3.5 rounded-xl text-sm shadow-lg shadow-blue-500/20 transition-all flex items-center justify-center gap-2 mt-6 disabled:opacity-50"
          >
            {isLoading ? <RefreshCw className="w-4 h-4 animate-spin" /> : "ĐĂNG NHẬP HỆ THỐNG"}
          </button>
        </form>

        <div className="mt-8 text-center text-xs text-slate-400 font-mono border-t border-slate-100 pt-4">
          Mật khẩu tài khoản mẫu: <span className="font-bold text-[#2161D9]">superManager / 123456</span>
        </div>
      </div>
    </div>
  );
}
