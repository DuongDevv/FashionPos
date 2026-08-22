"use client";

import React, { useEffect, useState } from "react";
import Sidebar from "@/components/Sidebar";
import { Users, Award, Phone, DollarSign, Search, UserPlus } from "lucide-react";

interface Customer {
  id: number;
  fullName: string;
  phoneNumber: string;
  totalSpent: number;
  loyaltyPoints: number;
  membershipTier: string;
}

export default function CustomersPage() {
  const [customers, setCustomers] = useState<Customer[]>([
    {
      id: 1,
      fullName: "Khách Hàng VVIP",
      phoneNumber: "0906834761",
      totalSpent: 2100000.0,
      loyaltyPoints: 2100,
      membershipTier: "BLACK",
    },
  ]);
  const [search, setSearch] = useState<string>("");

  const filteredCustomers = customers.filter(
    (c) => c.fullName.toLowerCase().includes(search.toLowerCase()) || c.phoneNumber.includes(search)
  );

  const getTierBadge = (tier: string) => {
    switch (tier) {
      case "BLACK":
        return <span className="bg-slate-900 text-amber-400 font-extrabold px-3 py-1 rounded-full text-xs border border-amber-500/30">HẠNG ĐEN (VVIP)</span>;
      case "GOLD":
        return <span className="bg-amber-100 text-amber-800 font-bold px-3 py-1 rounded-full text-xs border border-amber-300">HẠNG VÀNG</span>;
      case "SILVER":
        return <span className="bg-slate-200 text-slate-700 font-bold px-3 py-1 rounded-full text-xs border border-slate-300">HẠNG BẠC</span>;
      default:
        return <span className="bg-orange-100 text-orange-800 font-bold px-3 py-1 rounded-full text-xs border border-orange-200">HẠNG ĐỒNG</span>;
    }
  };

  return (
    <div className="flex h-screen bg-slate-100 text-slate-800 font-sans overflow-hidden">
      <Sidebar />

      <main className="flex-1 overflow-y-auto p-8">
        {/* Header */}
        <div className="flex items-center justify-between mb-8">
          <div>
            <h1 className="text-2xl font-extrabold text-slate-900 flex items-center gap-2">
              <Users className="w-7 h-7 text-[#2161D9]" /> QUẢN LÝ KHÁCH HÀNG & TÍCH ĐIỂM
            </h1>
            <p className="text-xs text-slate-500 mt-1">Danh sách thành viên, tích lũy điểm thưởng và phân hạng tự động</p>
          </div>
          <button className="bg-[#2161D9] hover:bg-blue-700 text-white font-bold px-5 py-2.5 rounded-xl text-xs flex items-center gap-2 shadow-md shadow-blue-500/20 transition-all">
            <UserPlus className="w-4 h-4" /> Thêm Khách Hàng
          </button>
        </div>

        {/* Form Tìm Kiếm */}
        <div className="bg-white p-4 rounded-2xl border border-slate-200 shadow-sm mb-6 flex justify-between items-center">
          <div className="relative w-96">
            <Search className="absolute left-3.5 top-3 text-slate-400 w-4 h-4" />
            <input
              type="text"
              value={search}
              onChange={(e) => setSearch(e.target.value)}
              placeholder="Tìm theo tên hoặc số điện thoại khách hàng..."
              className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl pl-10 pr-4 py-2 text-xs text-slate-900 placeholder-slate-400 outline-none transition-all"
            />
          </div>
          <span className="text-xs font-mono text-slate-500">Tổng số: {filteredCustomers.length} khách hàng</span>
        </div>

        {/* Bảng Khách Hàng */}
        <div className="bg-white border border-slate-200 rounded-2xl overflow-hidden shadow-sm">
          <table className="w-full text-left text-sm">
            <thead className="bg-[#F0F5FF] text-[#2161D9] font-mono text-xs uppercase border-b border-slate-200">
              <tr>
                <th className="p-4 font-bold">Khách Hàng</th>
                <th className="p-4 font-bold">Số Điện Thoại</th>
                <th className="p-4 font-bold text-right">Tổng Chi Tiêu</th>
                <th className="p-4 font-bold text-center">Điểm Tích Lũy</th>
                <th className="p-4 text-center font-bold">Hạng Thành Viên</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-100">
              {filteredCustomers.map((c) => (
                <tr key={c.id} className="hover:bg-blue-50/40 transition-colors">
                  <td className="p-4 font-bold text-slate-900 flex items-center gap-3">
                    <div className="w-9 h-9 rounded-full bg-blue-100 text-[#2161D9] font-bold text-xs flex items-center justify-center">
                      {c.fullName.slice(0, 2).toUpperCase()}
                    </div>
                    <span>{c.fullName}</span>
                  </td>
                  <td className="p-4 font-mono text-slate-700">
                    <span className="inline-flex items-center gap-1">
                      <Phone className="w-3.5 h-3.5 text-slate-400" /> {c.phoneNumber}
                    </span>
                  </td>
                  <td className="p-4 font-mono font-extrabold text-right text-emerald-600">
                    {c.totalSpent.toLocaleString("vi-VN")}đ
                  </td>
                  <td className="p-4 font-mono font-bold text-center text-[#2161D9]">
                    <span className="inline-flex items-center gap-1 bg-blue-50 px-3 py-1 rounded-full border border-blue-200">
                      <Award className="w-3.5 h-3.5" /> +{c.loyaltyPoints} điểm
                    </span>
                  </td>
                  <td className="p-4 text-center">{getTierBadge(c.membershipTier)}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </main>
    </div>
  );
}
