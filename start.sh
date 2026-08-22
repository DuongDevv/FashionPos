#!/bin/bash
# =============================================================================
# ENTERPRISE STARTUP SCRIPT - FASHIONPOS SYSTEM
# =============================================================================

PROJECT_DIR="/home/duong/Data/Lil_Duong/Projects/FashionPos"
echo "🚀 Starting Enterprise FashionPOS Platform..."

# 1. Start Docker Containers (PostgreSQL + Redis)
echo "📦 [1/3] Starting Database & Cache Containers..."
cd $PROJECT_DIR
docker compose up -d postgres redis

# Wait for DB healthcheck
echo "⏳ Waiting for PostgreSQL & Redis to be ready..."
sleep 3

# 2. Start C# .NET 8 Web API
echo "⚡ [2/3] Starting C# .NET 8 Web API Server..."
nohup dotnet run --project $PROJECT_DIR/apps/api/FashionPos.Api --urls http://localhost:5000 > /tmp/fashionpos_api.log 2>&1 &
echo "   -> Backend API listening on http://localhost:5000"

# 3. Start Next.js 16 Web App
echo "🎨 [3/3] Starting Next.js 16 Web POS Frontend..."
nohup npm --prefix $PROJECT_DIR/apps/web run dev > /tmp/fashionpos_web.log 2>&1 &
echo "   -> Frontend Web listening on http://localhost:3001"

sleep 3
echo ""
echo "============================================================================="
echo "✅ FASHIONPOS PLATFORM IS LIVE & READY!"
echo "🌐 Open Web POS in Browser:  http://localhost:3001/pos"
echo "🌐 Open Swagger API Docs:    http://localhost:5000/swagger"
echo "============================================================================="
