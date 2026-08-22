"use client";

import React, { useEffect, useState } from "react";
import Sidebar from "@/components/Sidebar";
import { Settings, Save, RefreshCw, CheckCircle2 } from "lucide-react";

interface SystemSetting {
  settingKey: string;
  settingValue: string;
  description: string;
}

export default function SettingsPage() {
  const [settings, setSettings] = useState<SystemSetting[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [isSaved, setIsSaved] = useState<boolean>(false);

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

  const handleChange = (key: string, value: string) => {
    setSettings((prev) =>
      prev.map((s) => (s.settingKey === key ? { ...s, settingValue: value } : s))
    );
  };

  const handleSave = (e: React.FormEvent) => {
    e.preventDefault();
    setIsSaved(true);
    setTimeout(() => setIsSaved(false), 3000);
  };

  return (
    <div className="flex h-screen bg-slate-100 text-slate-800 font-sans overflow-hidden">
      <Sidebar />

      <main className="flex-1 overflow-y-auto p-8">
        {/* Header */}
        <div className="flex items-center justify-between mb-8">
          <div>
            <h1 className="text-2xl font-extrabold text-slate-900 flex items-center gap-2">
              <Settings className="w-7 h-7 text-[#2161D9]" /> CẤU HÌNH HỆ THỐNG (SYSTEM SETTINGS)
            </h1>
            <p className="text-xs text-slate-500 mt-1">Thông tin cửa hàng, hóa đơn và các kênh liên hệ PostgreSQL</p>
          </div>
          <button
            onClick={handleSave}
            className="bg-[#2161D9] hover:bg-blue-700 text-white font-bold px-6 py-2.5 rounded-xl text-xs flex items-center gap-2 shadow-md shadow-blue-500/20 transition-all"
          >
            <Save className="w-4 h-4" /> Lưu Cấu Hình
          </button>
        </div>

        {isSaved && (
          <div className="mb-6 p-4 bg-emerald-50 border border-emerald-200 text-emerald-700 rounded-xl text-sm flex items-center gap-2 shadow-sm font-semibold">
            <CheckCircle2 className="w-5 h-5 text-emerald-600" /> Cập nhật cấu hình hệ thống thành công!
          </div>
        )}

        {/* Form Cấu Hình */}
        <div className="bg-white border border-slate-200 rounded-2xl p-6 shadow-sm max-w-3xl">
          {isLoading ? (
            <div className="p-12 text-center text-slate-400 flex items-center justify-center gap-2 font-mono">
              <RefreshCw className="w-5 h-5 animate-spin text-[#2161D9]" /> Đang tải cấu hình...
            </div>
          ) : (
            <form onSubmit={handleSave} className="space-y-4">
              {settings.map((s) => (
                <div key={s.settingKey} className="flex flex-col gap-1">
                  <label className="text-xs font-mono uppercase text-slate-500 font-bold">
                    {s.description || s.settingKey} ({s.settingKey}):
                  </label>
                  <input
                    type="text"
                    value={s.settingValue || ""}
                    onChange={(e) => handleChange(s.settingKey, e.target.value)}
                    className="w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] rounded-xl px-4 py-2.5 text-sm text-slate-900 outline-none transition-all font-sans"
                  />
                </div>
              ))}
            </form>
          )}
        </div>
      </main>
    </div>
  );
}
