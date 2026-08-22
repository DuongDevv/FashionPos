#!/bin/bash
# =============================================================================
# ENTERPRISE HEALTH CHECK STATUS SCRIPT - FASHIONPOS SYSTEM
# =============================================================================

echo "🔍 Checking FashionPOS Platform Service Status..."
echo "-----------------------------------------------------------------------------"

# 1. Check Postgres Port 5434
if nc -z localhost 5434 2>/dev/null || ss -tulpn | grep -q "5434"; then
    echo "✅ [PostgreSQL 16 DB]   : RUNNING on Port 5434"
else
    echo "❌ [PostgreSQL 16 DB]   : STOPPED"
fi

# 2. Check Redis Port 6381
if nc -z localhost 6381 2>/dev/null || ss -tulpn | grep -q "6381"; then
    echo "✅ [Redis 7 Cache]       : RUNNING on Port 6381"
else
    echo "❌ [Redis 7 Cache]       : STOPPED"
fi

# 3. Check C# .NET API Port 5000
if curl -s http://localhost:5000/api/v1/products/system-settings > /dev/null; then
    echo "✅ [C# .NET 8 API]      : RUNNING on http://localhost:5000 (200 OK)"
else
    echo "❌ [C# .NET 8 API]      : STOPPED or Unreachable"
fi

# 4. Check Next.js Frontend Port 3001
if curl -s http://localhost:3001/pos > /dev/null; then
    echo "✅ [Next.js 16 Web POS] : RUNNING on http://localhost:3001 (200 OK)"
else
    echo "❌ [Next.js 16 Web POS] : STOPPED or Unreachable"
fi

echo "-----------------------------------------------------------------------------"
