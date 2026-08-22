#!/bin/bash
# =============================================================================
# ENTERPRISE SHUTDOWN SCRIPT - FASHIONPOS SYSTEM
# =============================================================================

PROJECT_DIR="/home/duong/Data/Lil_Duong/Projects/FashionPos"
echo "🛑 Stopping Enterprise FashionPOS Platform..."

# 1. Kill Dotnet API process
pkill -f "FashionPos.Api" || true
echo "   -> Stopped .NET 8 Backend API"

# 2. Kill Next.js Web process
pkill -f "next-server" || true
pkill -f "fashionpos-web" || true
echo "   -> Stopped Next.js Frontend Web"

# 3. Stop Docker Containers
cd $PROJECT_DIR
docker compose stop postgres redis || true
echo "   -> Stopped Docker PostgreSQL & Redis"

echo "✅ All FashionPOS services stopped safely!"
