# =============================================================================
# MULTI-STAGE DOCKERFILE FOR ENTERPRISE NESTJS BACKEND
# Target: Minimal image size (~120MB), Non-root user, Maximum security & speed
# =============================================================================

# STAGE 1: Dependencies
FROM node:20-alpine AS deps
RUN apk add --no-libc6-compat
WORKDIR /app

COPY package*.json ./
RUN npm ci

# STAGE 2: Builder
FROM node:20-alpine AS builder
WORKDIR /app
COPY --from=deps /app/node_modules ./node_modules
COPY . .

RUN npm run build

# STAGE 3: Production Runner
FROM node:20-alpine AS runner
WORKDIR /app

ENV NODE_ENV=production
ENV PORT=3000

# Security: Create non-root app user
RUN addgroup --system --gid 1001 nodejs && \
    adduser --system --uid 1001 nestjs

COPY package*.json ./
RUN npm ci --only=production && npm cache clean --force

COPY --from=builder --chown=nestjs:nodejs /app/dist ./dist

# Switch to unprivileged user
USER nestjs

EXPOSE 3000

CMD ["node", "dist/main.js"]
