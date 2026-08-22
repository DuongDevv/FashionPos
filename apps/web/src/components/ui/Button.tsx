"use client";

import React from "react";
import { RefreshCw } from "lucide-react";

export interface ButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: "primary" | "secondary" | "success" | "danger" | "outline";
  size?: "sm" | "md" | "lg";
  isLoading?: boolean;
  icon?: React.ReactNode;
}

export default function Button({
  children,
  variant = "primary",
  size = "md",
  isLoading = false,
  icon,
  className = "",
  disabled,
  ...props
}: ButtonProps) {
  const baseStyles = "font-bold rounded-xl transition-all flex items-center justify-center gap-2 shadow-sm border outline-none disabled:opacity-50 disabled:cursor-not-allowed";

  const variantStyles = {
    primary: "bg-[#2161D9] hover:bg-blue-700 text-white border-[#2161D9] shadow-blue-500/20",
    secondary: "bg-slate-100 hover:bg-slate-200 text-slate-700 border-slate-200",
    success: "bg-emerald-600 hover:bg-emerald-500 text-white border-emerald-600 shadow-emerald-600/20",
    danger: "bg-red-600 hover:bg-red-500 text-white border-red-600 shadow-red-500/20",
    outline: "bg-white hover:bg-slate-50 text-slate-700 border-slate-300",
  };

  const sizeStyles = {
    sm: "px-3 py-1.5 text-xs",
    md: "px-5 py-2.5 text-xs",
    lg: "px-6 py-3.5 text-sm",
  };

  return (
    <button
      disabled={disabled || isLoading}
      className={`${baseStyles} ${variantStyles[variant]} ${sizeStyles[size]} ${className}`}
      {...props}
    >
      {isLoading ? <RefreshCw className="w-4 h-4 animate-spin" /> : icon}
      <span>{children}</span>
    </button>
  );
}
