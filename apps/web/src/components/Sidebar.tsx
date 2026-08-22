"use client";

import React, { useState, useEffect } from "react";
import Link from "next/link";
import { usePathname, useRouter } from "next/navigation";
import { 
  ShoppingCart, 
  LayoutDashboard, 
  Package, 
  Users, 
  Truck, 
  Settings, 
  LogOut,
  LogIn,
  User,
  ShieldCheck,
  Menu,
  X
} from "lucide-react";

interface UserInfo {
  employeeId: number;
  fullName: string;
  username: string;
  role: string;
  token: string;
}

export default function Sidebar() {
  const pathname = usePathname();
  const router = useRouter();
  const [currentUser, setCurrentUser] = useState<UserInfo | null>(null);
  const [isMobileOpen, setIsMobileOpen] = useState(false);

  useEffect(() => {
    const savedUser = localStorage.getItem("pos_user");
    if (savedUser) {
      try {
        setCurrentUser(JSON.parse(savedUser));
      } catch {
        setCurrentUser(null);
      }
    }
  }, []);

  const handleLogout = () => {
    localStorage.removeItem("pos_token");
    localStorage.removeItem("pos_user");
    setCurrentUser(null);
    router.push("/login");
  };

  const navItems = [
    { name: "Bán Hàng POS", href: "/pos", icon: ShoppingCart },
    { name: "Dashboard", href: "/dashboard", icon: LayoutDashboard },
    { name: "Sản Phẩm & Kho", href: "/products", icon: Package },
    { name: "Khách Hàng", href: "/customers", icon: Users },
    { name: "Nhân Viên", href: "/staff", icon: ShieldCheck },
    { name: "Nhập Hàng Kho", href: "/stock-in", icon: Truck },
    { name: "Cấu Hình", href: "/settings", icon: Settings },
  ];

  const SidebarContent = () => (
    <div className="w-64 bg-white border-r border-slate-200 flex flex-col justify-between p-4 h-full font-sans">
      <div>
        {/* Brand Logo */}
        <div className="flex items-center justify-between px-3 py-4 mb-6 border-b border-slate-100">
          <div className="flex items-center gap-3">
            <div className="w-10 h-10 rounded-xl bg-[#2161D9] flex items-center justify-center text-white font-bold text-xl shadow-md shadow-blue-500/20">
              N
            </div>
            <div>
              <h1 className="font-extrabold text-slate-900 text-base leading-none">NQD FASHION</h1>
              <span className="text-[10px] font-mono text-[#2161D9] font-bold">ENTERPRISE POS</span>
            </div>
          </div>
          {/* Nút đóng trên mobile */}
          <button onClick={() => setIsMobileOpen(false)} className="md:hidden text-slate-400 hover:text-slate-600">
            <X className="w-6 h-6" />
          </button>
        </div>

        {/* Nav Links */}
        <nav className="space-y-1">
          {navItems.map((item) => {
            const Icon = item.icon;
            const isActive = pathname === item.href;

            return (
              <Link
                key={item.href}
                href={item.href}
                onClick={() => setIsMobileOpen(false)}
                className={`flex items-center gap-3 px-4 py-3 rounded-xl text-sm font-bold transition-all ${
                  isActive
                    ? "bg-[#2161D9] text-white shadow-md shadow-blue-500/20"
                    : "text-slate-600 hover:bg-slate-50 hover:text-slate-900"
                }`}
              >
                <Icon className={`w-5 h-5 ${isActive ? "text-white" : "text-slate-400"}`} />
                <span>{item.name}</span>
              </Link>
            );
          })}
        </nav>
      </div>

      {/* User Auth Section ở Chân Sidebar */}
      <div className="pt-4 border-t border-slate-100">
        {currentUser ? (
          <div className="flex items-center justify-between px-2 bg-slate-50 p-2.5 rounded-xl border border-slate-200">
            <div className="flex items-center gap-2.5 overflow-hidden">
              <div className="w-8 h-8 rounded-full bg-blue-100 text-[#2161D9] font-bold text-xs flex items-center justify-center flex-shrink-0">
                <User className="w-4 h-4" />
              </div>
              <div className="text-xs truncate">
                <p className="font-bold text-slate-900 leading-tight truncate">{currentUser.fullName}</p>
                <p className="text-[10px] text-[#2161D9] font-mono font-bold truncate">{currentUser.role}</p>
              </div>
            </div>
            <button
              onClick={handleLogout}
              title="Đăng xuất"
              className="text-slate-400 hover:text-red-500 p-1.5 transition-colors flex-shrink-0"
            >
              <LogOut className="w-4 h-4" />
            </button>
          </div>
        ) : (
          <Link
            href="/login"
            onClick={() => setIsMobileOpen(false)}
            className="w-full bg-[#2161D9] hover:bg-blue-700 text-white font-bold py-2.5 px-4 rounded-xl text-xs flex items-center justify-center gap-2 shadow-md shadow-blue-500/20 transition-all"
          >
            <LogIn className="w-4 h-4" /> Đăng Nhập Quản Trị
          </Link>
        )}
      </div>
    </div>
  );

  return (
    <>
      {/* 1. Desktop Sidebar */}
      <div className="hidden md:block h-screen flex-shrink-0">
        <SidebarContent />
      </div>

      {/* 2. Mobile Floating Hamburger Toggle */}
      <div className="md:hidden fixed top-4 left-4 z-40">
        <button
          onClick={() => setIsMobileOpen(true)}
          className="bg-white border border-slate-200 text-slate-700 p-2.5 rounded-xl shadow-md focus:outline-none"
        >
          <Menu className="w-6 h-6 text-[#2161D9]" />
        </button>
      </div>

      {/* 3. Mobile Sliding Drawer Overlay */}
      {isMobileOpen && (
        <div className="fixed inset-0 z-50 bg-slate-900/50 backdrop-blur-sm md:hidden flex">
          <div className="relative animate-in slide-in-from-left duration-200">
            <SidebarContent />
          </div>
          <div className="flex-1" onClick={() => setIsMobileOpen(false)}></div>
        </div>
      )}
    </>
  );
}
