"use client";

import React from "react";

export interface InputProps extends React.InputHTMLAttributes<HTMLInputElement> {
  label?: string;
  error?: string;
  icon?: React.ReactNode;
}

export default function Input({ label, error, icon, className = "", ...props }: InputProps) {
  return (
    <div className="flex flex-col gap-1 w-full">
      {label && <label className="text-xs font-mono uppercase text-slate-500 font-bold">{label}</label>}
      <div className="relative flex items-center">
        {icon && <div className="absolute left-3.5 text-slate-400">{icon}</div>}
        <input
          className={`w-full bg-slate-50 border border-slate-300 focus:border-[#2161D9] focus:ring-2 focus:ring-blue-100 rounded-xl py-2.5 text-sm text-slate-900 placeholder-slate-400 outline-none transition-all ${
            icon ? "pl-10 pr-4" : "px-4"
          } ${error ? "border-red-500 focus:border-red-500 focus:ring-red-100" : ""} ${className}`}
          {...props}
        />
      </div>
      {error && <span className="text-xs text-red-500 font-semibold mt-0.5">{error}</span>}
    </div>
  );
}
