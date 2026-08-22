"use client";

import React, { useState } from "react";
import Sidebar from "@/components/Sidebar";
import { Truck, Plus, Search, CheckCircle2, ArrowDownRight } from "lucide-react";

export default function StockInPage() {
  const [purchaseOrders, setPurchaseOrders] = useState([
    {
      id: 1,
      poCode: "PN00001",
      supplierName: "Gucci Vietnam Supplier",
      employeeName: "Anh Đương",
      totalAmount: 4000000.0,
      createdAt: "2026-08-22 17:00",
    },
  ]);

  return (
    <div className="flex h-screen bg-slate-100 text-slate-800 font-sans overflow-hidden">
      <Sidebar />

      <main className="flex-1 overflow-y-auto p-8">
        {/* Header */}
        <div className="flex items-center justify-between mb-8">
          <div>
            <h1 className="text-2xl font-extrabold text-slate-900 flex items-center gap-2">
              <Truck className="w-7 h-7 text-[#2161D9]" /> QUẢN LÝ NHẬP HÀNG KHO (PURCHASE ORDERS)
            </h1>
            <p className="text-xs text-slate-500 mt-1">Tạo phiếu nhập kho từ nhà cung cấp, cập nhật giá nhập và tồn kho</p>
          </div>
          <button className="bg-[#2161D9] hover:bg-blue-700 text-white font-bold px-5 py-2.5 rounded-xl text-xs flex items-center gap-2 shadow-md shadow-blue-500/20 transition-all">
            <Plus className="w-4 h-4" /> Tạo Phiếu Nhập Kho Mới
          </button>
        </div>

        {/* Form Tìm Kiếm */}
        <div className="bg-white p-4 rounded-2xl border border-slate-200 shadow-sm mb-6 flex justify-between items-center">
          <div className="relative w-96">
            <Search className="absolute left-3.5 top-3 text-slate-400 w-4 h-4" />
            <input
              type="text"
              placeholder="Tìm kiếm phiếu nhập theo mã PN hoặc tên nhà cung cấp..."
              className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl pl-10 pr-4 py-2 text-xs text-slate-900 placeholder-slate-400 outline-none transition-all"
            />
          </div>
          <span className="text-xs font-mono text-slate-500">Tổng số: {purchaseOrders.length} phiếu nhập</span>
        </div>

        {/* Bảng Phiếu Nhập Kho */}
        <div className="bg-white border border-slate-200 rounded-2xl overflow-hidden shadow-sm">
          <table className="w-full text-left text-sm">
            <thead className="bg-[#F0F5FF] text-[#2161D9] font-mono text-xs uppercase border-b border-slate-200">
              <tr>
                <th className="p-4 font-bold">Mã Phiếu Nhập</th>
                <th className="p-4 font-bold">Nhà Cung Cấp</th>
                <th className="p-4 font-bold">Nhân Viên Nhập</th>
                <th className="p-4 font-bold text-right">Tổng Tiền Nhập</th>
                <th className="p-4 text-center font-bold">Thời Gian</th>
                <th className="p-4 text-center font-bold">Trạng Thái</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-100">
              {purchaseOrders.map((po) => (
                <tr key={po.id} className="hover:bg-blue-50/40 transition-colors">
                  <td className="p-4 font-mono font-extrabold text-[#2161D9]">{po.poCode}</td>
                  <td className="p-4 font-bold text-slate-900">{po.supplierName}</td>
                  <td className="p-4 font-semibold text-slate-700">{po.employeeName}</td>
                  <td className="p-4 font-mono font-extrabold text-right text-emerald-600">
                    {po.totalAmount.toLocaleString("vi-VN")}đ
                  </td>
                  <td className="p-4 font-mono text-xs text-center text-slate-500">{po.createdAt}</td>
                  <td className="p-4 text-center">
                    <span className="inline-flex items-center gap-1 text-[11px] font-bold text-emerald-700 bg-emerald-50 px-3 py-1 rounded-full border border-emerald-200">
                      <CheckCircle2 className="w-3.5 h-3.5" /> đã Nhập Kho
                    </span>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </main>
    </div>
  );
}
