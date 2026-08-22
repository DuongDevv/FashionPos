"use client";

import React, { useEffect, useState } from "react";
import Sidebar from "@/components/Sidebar";
import { 
  TrendingUp, 
  ShoppingBag, 
  Users, 
  AlertTriangle, 
  DollarSign, 
  ArrowUpRight, 
  RefreshCw 
} from "lucide-react";

interface SystemSetting {
  settingKey: string;
  settingValue: string;
  description: string;
}

export default function DashboardPage() {
  const [settings, setSettings] = useState<SystemSetting[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(true);

  const API_BASE_URL = "http://localhost:5000/api/v1";

  useEffect(() => {
    fetch(`${API_BASE_URL}/products/system-settings`)
      .then((res) => res.json())
      .then((data) => {
        if (data.success) {
          setSettings(data.data);
        }
      })
      .catch((err) => console.error(err))
      .finally(() => setIsLoading(false));
  }, []);

  const getSetting = (key: string) => {
    return settings.find((s) => s.settingKey === key)?.settingValue || "Đang tải...";
  };

  return (
    <div className="flex h-screen bg-slate-100 text-slate-800 font-sans overflow-hidden">
      <Sidebar />

      <main className="flex-1 overflow-y-auto p-8">
        {/* Header */}
        <div className="flex items-center justify-between mb-8">
          <div>
            <h1 className="text-2xl font-extrabold text-slate-900">BÁO CÁO & TỔNG QUAN HỆ THỐNG</h1>
            <p className="text-xs text-slate-500 mt-1">Theo dõi doanh thu, tồn kho và chỉ số kinh doanh real-time</p>
          </div>
          <button 
            onClick={() => window.location.reload()}
            className="bg-white border border-slate-200 text-slate-700 hover:bg-slate-50 font-bold px-4 py-2 rounded-xl text-xs flex items-center gap-2 shadow-sm transition-all"
          >
            <RefreshCw className="w-3.5 h-3.5" /> Làm mới dữ liệu
          </button>
        </div>

        {/* 4 Cards Thống Kê Chính */}
        <div className="grid grid-cols-4 gap-6 mb-8">
          {/* Card 1: Doanh Thu */}
          <div className="bg-white p-6 rounded-2xl border border-slate-200 shadow-sm relative overflow-hidden">
            <div className="flex items-center justify-between mb-4">
              <span className="text-xs font-mono uppercase text-slate-400 font-bold">Doanh Thu Hôm Nay</span>
              <div className="w-10 h-10 rounded-xl bg-blue-50 text-[#2161D9] flex items-center justify-center">
                <DollarSign className="w-5 h-5" />
              </div>
            </div>
            <p className="text-2xl font-extrabold text-slate-900 font-mono">400,000đ</p>
            <span className="inline-flex items-center gap-1 text-[11px] font-bold text-emerald-600 mt-2 bg-emerald-50 px-2 py-0.5 rounded-md">
              <ArrowUpRight className="w-3 h-3" /> +100% so với hôm qua
            </span>
          </div>

          {/* Card 2: Đơn Hàng */}
          <div className="bg-white p-6 rounded-2xl border border-slate-200 shadow-sm relative overflow-hidden">
            <div className="flex items-center justify-between mb-4">
              <span className="text-xs font-mono uppercase text-slate-400 font-bold">Tổng Đơn Hàng POS</span>
              <div className="w-10 h-10 rounded-xl bg-emerald-50 text-emerald-600 flex items-center justify-center">
                <ShoppingBag className="w-5 h-5" />
              </div>
            </div>
            <p className="text-2xl font-extrabold text-slate-900 font-mono">1 Đơn Hàng</p>
            <span className="text-[11px] font-semibold text-slate-500 mt-2 block">
              Trạng thái: Hoàn tất 100%
            </span>
          </div>

          {/* Card 3: Khách Hàng */}
          <div className="bg-white p-6 rounded-2xl border border-slate-200 shadow-sm relative overflow-hidden">
            <div className="flex items-center justify-between mb-4">
              <span className="text-xs font-mono uppercase text-slate-400 font-bold">Khách Hàng VVIP</span>
              <div className="w-10 h-10 rounded-xl bg-purple-50 text-purple-600 flex items-center justify-center">
                <Users className="w-5 h-5" />
              </div>
            </div>
            <p className="text-2xl font-extrabold text-slate-900 font-mono">1 Khách VVIP</p>
            <span className="inline-flex items-center gap-1 text-[11px] font-bold text-purple-600 mt-2 bg-purple-50 px-2 py-0.5 rounded-md">
              Hạng Đen (VVIP)
            </span>
          </div>

          {/* Card 4: Tồn Kho Sụt Giảm */}
          <div className="bg-white p-6 rounded-2xl border border-slate-200 shadow-sm relative overflow-hidden">
            <div className="flex items-center justify-between mb-4">
              <span className="text-xs font-mono uppercase text-slate-400 font-bold">Cảnh Báo Tồn Kho</span>
              <div className="w-10 h-10 rounded-xl bg-amber-50 text-amber-600 flex items-center justify-center">
                <AlertTriangle className="w-5 h-5" />
              </div>
            </div>
            <p className="text-2xl font-extrabold text-amber-600 font-mono">1 Biến Thể</p>
            <span className="text-[11px] font-semibold text-amber-700 mt-2 block">
              Mã SKU-AO-001 còn 8 cái
            </span>
          </div>
        </div>

        {/* Khối Thông Tin Cửa Hàng & Bảng Sản Phẩm Bán Chạy */}
        <div className="grid grid-cols-3 gap-6">
          {/* Top Selling Products */}
          <div className="col-span-2 bg-white p-6 rounded-2xl border border-slate-200 shadow-sm">
            <h3 className="text-base font-bold text-slate-900 mb-4 flex items-center gap-2">
              <TrendingUp className="w-5 h-5 text-[#2161D9]" /> SẢN PHẨM BÁN CHẠY NHẤT HÔM NAY
            </h3>
            <table className="w-full text-left text-sm">
              <thead className="bg-[#F0F5FF] text-[#2161D9] font-mono text-xs uppercase border-b border-slate-200">
                <tr>
                  <th className="p-3 font-bold">Sản Phẩm</th>
                  <th className="p-3 font-bold">Mã SKU</th>
                  <th className="p-3 font-bold text-center">Đã Bán</th>
                  <th className="p-3 font-bold text-right">Doanh Thu</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                <tr className="hover:bg-slate-50">
                  <td className="p-3 font-bold text-slate-900">Áo Thun NQD Classic</td>
                  <td className="p-3 font-mono text-xs text-[#2161D9]">SKU-AO-001-XAM-36</td>
                  <td className="p-3 font-mono font-bold text-center">2 cái</td>
                  <td className="p-3 font-mono font-extrabold text-right text-emerald-600">400,000đ</td>
                </tr>
              </tbody>
            </table>
          </div>

          {/* System Settings Info */}
          <div className="bg-white p-6 rounded-2xl border border-slate-200 shadow-sm">
            <h3 className="text-base font-bold text-slate-900 mb-4 pb-3 border-b border-slate-100">
              THÔNG TIN CỬA HÀNG (SETTINGS)
            </h3>
            {isLoading ? (
              <p className="text-xs text-slate-400 font-mono">Đang tải cấu hình PostgreSQL...</p>
            ) : (
              <div className="space-y-3 text-xs font-sans">
                <div>
                  <span className="text-slate-400 block font-mono uppercase">Tên Cửa Hàng:</span>
                  <span className="font-bold text-slate-900 text-sm">{getSetting("TenCuaHang")}</span>
                </div>
                <div>
                  <span className="text-slate-400 block font-mono uppercase">Địa Chỉ:</span>
                  <span className="font-semibold text-slate-800">{getSetting("DiaChi")}</span>
                </div>
                <div>
                  <span className="text-slate-400 block font-mono uppercase">Số Điện Thoại / Zalo:</span>
                  <span className="font-mono font-bold text-[#2161D9]">{getSetting("SoDienThoai")}</span>
                </div>
                <div>
                  <span className="text-slate-400 block font-mono uppercase">Email Cửa Hàng:</span>
                  <span className="font-mono text-slate-700">{getSetting("Email")}</span>
                </div>
              </div>
            )}
          </div>
        </div>
      </main>
    </div>
  );
}
