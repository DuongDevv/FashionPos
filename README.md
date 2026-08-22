# 🛒 FASHIONPOS ENTERPRISE PLATFORM

[![NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Next.js 16](https://img.shields.io/badge/Next.js-16.2.6-000000?logo=next.js)](https://nextjs.org/)
[![PostgreSQL 16](https://img.shields.io/badge/PostgreSQL-16.0-4169E1?logo=postgresql)](https://www.postgresql.org/)
[![Redis 7](https://img.shields.io/badge/Redis-7.0-DC382D?logo=redis)](https://redis.io/)
[![Docker](https://img.shields.io/badge/Docker-Enabled-2496ED?logo=docker)](https://www.docker.com/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

> **Legacy System Migration**: A high-concurrency retail POS & E-Commerce platform refactored and modernized from a legacy C# WinForms / MS SQL Server 2-tier desktop application into a 3-tier Enterprise Web Platform (**C# .NET 8 Web API + PostgreSQL 16 + Redis 7 + Next.js 16 App Router**).

---

## 🌟 KEY ENTERPRISE FEATURES

### 1. 🛒 POS Cashier Terminal
- **High-Speed Barcode SKU Scanner**: Instant product variant lookup by SKU with sub-5ms database query latency.
- **Real-Time Cart Engine**: Dynamic item calculations, discount handling, and database-level stock limit enforcement preventing overbooking.
- **Payment & Cash Calculator**: Supports Cash, VNPAY, Momo, and Bank Transfer with automated change calculation (`paidAmount - finalAmount`).
- **Thermal Receipt Modal**: Displays formatted invoice receipts (`HD...`), itemized breakdown, calculated change due, and earned loyalty points.

### 2. 📱 Customer Phone Lookup & Auto Loyalty Engine
- **Instant Phone Lookup**: Search customer profiles directly on the POS screen by phone number to view Name, Current Points, Total Spent, and Tier Badges (**Bronze, Silver, Gold, Black VVIP**).
- **On-the-Spot Member Registration**: If a phone number is unregistered, a 1-click modal pops up to register the new customer and immediately bind them to the active checkout transaction.
- **Automated Membership Tier Upgrades**: PostgreSQL database triggers automatically calculate loyalty points (`10,000 VND = 1 point`) and upgrade member tiers upon transaction completion.

### 3. 🛡️ Role-Based Access Control & JWT Security
- **BCrypt Password Hashing**: Hashed credentials stored securely in PostgreSQL.
- **Signed JWT Authentication**: Generates HMAC-SHA256 signed JWT Access Tokens containing user claims (`employeeId`, `fullName`, `role`).
- **Role Enforcement (RBAC)**: `SUPER_MANAGER`, `STORE_MANAGER`, `CASHIER`, and `WAREHOUSE_STAFF`.

### 4. 📦 Inventory & Anti-Overselling Guard
- **Concurrency Guards**: Prevents negative inventory at both database constraints (`CHECK stock_quantity >= 0`) and EF Core ACID `IDbContextTransaction` levels.
- **Product & Variant Management**: Modal form for creating products, SKU barcodes, sizes, colors, and initial stock quantities.

### 5. 📊 Executive Analytics Dashboard
- Live tracking of today's revenue, POS order counts, VVIP customer metrics, and low-stock alerts (`< 10` units).

---

## 🛠️ TECH STACK BLUEPRINT

| Domain | Technology | Engineering Highlights |
| :--- | :--- | :--- |
| **Backend API** | **C# .NET 8 Web API** | EF Core 8, Npgsql Custom Enum Translators, Swagger OpenAPI, BCrypt, JWT |
| **Database** | **PostgreSQL 16** | ACID Transactions, Stored Procedures, Automated Triggers, Composite Indexes |
| **In-Memory Cache** | **Redis 7** | Distributed Locking & Caching Layer |
| **Frontend Web** | **Next.js 16 (App Router)** | React 19, TypeScript, Tailwind CSS (Royal Blue `#2161D9` Theme), Lucide Icons |
| **Container & DevOps** | **Docker & Nginx** | Multi-stage Dockerfile (~120MB), Docker Compose, Next.js Server Proxy Rewrites |

---

## 🏗️ MONOREPO ARCHITECTURE

```
FashionPos/
├── apps/
│   ├── api/                 # Backend REST API Server (C# .NET 8 Web API)
│   │   └── FashionPos.Api/
│   │       ├── Controllers/ # Auth, Orders, Products, Variants, Customers, Employees
│   │       ├── Data/        # EF Core DbContext & PostgreSQL Enum Mappings
│   │       ├── DTOs/        # Data Transfer Objects
│   │       └── Services/    # Order Creation ACID Transaction Service
│   └── web/                 # Frontend POS Web Application (Next.js 16)
│       ├── src/app/         # App Router: /pos, /dashboard, /products, /customers, /staff, /settings, /login
│       └── src/components/  # Navigation Sidebar & Enterprise UI Components (Button, Badge, Input, Card)
├── infrastructure/          # Docker PostgreSQL, Redis, Nginx & SQL Scripts
│   ├── db/                  # init.sql (PostgreSQL Enterprise Schema & Seed Data)
│   └── nginx/               # nginx.conf (Reverse Proxy & Security Headers)
├── legacy_winforms/         # Archived Legacy C# WinForms Desktop App
├── docs/                    # Architecture Diagrams & ERD Specifications
├── start.sh                 # 1-Click startup script for all services
├── stop.sh                  # 1-Click clean shutdown script
└── status.sh                # 1-Click healthcheck status script
```

---

## 🚀 QUICK START GUIDE (A TO Z)

### Prerequisites:
- **Node.js**: v18+ (Tested on Node.js v26)
- **.NET SDK**: .NET 8 SDK
- **Docker & Docker Compose**: For PostgreSQL 16 & Redis 7

### 1️⃣ Step 1: Clone Repository
```bash
git clone https://github.com/DuongDevv/FashionPos.git
cd FashionPos
```

### 2️⃣ Step 2: Execute 1-Click Startup Script
Run the automated control script to start Docker containers (PostgreSQL 16, Redis 7), C# .NET 8 API server, and Next.js 16 Web App:

```bash
chmod +x start.sh stop.sh status.sh
./start.sh
```

*(PostgreSQL 16 runs on host port 5434, Redis 7 on port 6381, .NET 8 API on port 5000, and Next.js Web POS on port 3001!)*

### 3️⃣ Step 3: Access Application in Browser
- 🛒 **Web POS Terminal**: [`http://localhost:3001/pos`](http://localhost:3001/pos)
- 🔑 **Login Portal**: [`http://localhost:3001/login`](http://localhost:3001/login)
- 📊 **Executive Dashboard**: [`http://localhost:3001/dashboard`](http://localhost:3001/dashboard)
- 🌐 **Swagger API Documentation**: [`http://localhost:5000/swagger`](http://localhost:5000/swagger)

---

## 💻 RUNNING THE LEGACY C# WINFORMS DESKTOP APP

If you want to run the legacy **C# WinForms Desktop Application** stored in `legacy_winforms/`:

### Prerequisites for Legacy App:
- Windows OS
- **Visual Studio 2019 / 2022** (with `.NET Desktop Development` workload)
- **Microsoft SQL Server** (SQL Express / Enterprise) & SSMS (SQL Server Management Studio)

### Execution Steps:
1. **Restore MS SQL Server Database**:
   - Open SSMS, create a database named `FashionPOS`.
   - Open `infrastructure/db/Fashion.sql` and click **Execute** to generate tables and seed data.
2. **Configure Connection String**:
   - Open `legacy_winforms/Source_FashionPos/DAL/DataHelper.cs` (or `App.config`).
   - Update connection string to point to your local SQL Server instance: `Server=.\SQLEXPRESS;Database=FashionPOS;Trusted_Connection=True;`.
3. **Launch in Visual Studio**:
   - Open `legacy_winforms/Source_FashionPos/WindowsFormsApp1.sln` in Visual Studio.
   - Press **F5** to build and run the legacy desktop app.

---

## 🔑 DEMO CREDENTIALS & TESTING DATA

- **Admin Account**: `superManager` / Password: `123456`
- **Customer Phone Test**: `0906834761` (VVIP Customer - Black Tier)
- **Barcode SKU Test**: `SKU-AO-001-XAM-36` (Áo Thun NQD Classic)

---

## 🛠️ OPERATIONAL SCRIPTS

- **Check Platform Status**: `./status.sh`
- **Stop All Services**: `./stop.sh`
- **Start Platform**: `./start.sh`

---

## 📜 LICENSE & CREDITS
© 2026 Developed by **Nguyễn Quốc Đương (DuongDevv)** - Software Engineering Student at Cao Thắng Technical College.
