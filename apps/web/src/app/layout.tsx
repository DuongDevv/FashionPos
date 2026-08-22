import type { Metadata } from "next";
import "./globals.css";

export const metadata: Metadata = {
  title: "FashionPOS Enterprise Terminal",
  description: "Phần mềm bán hàng POS thời trang cao cấp",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="vi">
      <body className="bg-slate-100 text-slate-800 min-h-screen antialiased">
        {children}
      </body>
    </html>
  );
}
