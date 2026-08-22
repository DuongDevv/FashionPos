import React from "react";

export interface BadgeProps {
  children: React.ReactNode;
  variant?: "success" | "warning" | "danger" | "info" | "black";
  className?: string;
}

export default function Badge({ children, variant = "info", className = "" }: BadgeProps) {
  const baseStyles = "inline-flex items-center gap-1.5 font-bold px-3 py-1 rounded-full text-xs font-mono border";

  const variantStyles = {
    success: "bg-emerald-50 text-emerald-700 border-emerald-200",
    warning: "bg-amber-50 text-amber-700 border-amber-200",
    danger: "bg-red-50 text-red-700 border-red-200",
    info: "bg-blue-50 text-[#2161D9] border-blue-200",
    black: "bg-slate-900 text-amber-400 border-amber-500/30 font-extrabold",
  };

  return <span className={`${baseStyles} ${variantStyles[variant]} ${className}`}>{children}</span>;
}
