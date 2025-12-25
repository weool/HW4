# ECommerce System - Интернет-магазин «Гоzон»

## Архитектура
- **Order Service** (порт 5001): управление заказами
- **Payment Service** (порт 5002): управление платежами
- **API Gateway** (порт 5000): единая точка входа

## Требования
- Docker Desktop
- Docker Compose

## Запуск системы
```bash
docker-compose up --build
```
# Сборка и запуск всех сервисов
docker-compose up --build

# Запуск в фоновом режиме
docker-compose up -d

# Проверка статуса
docker-compose ps

# Остановка
docker-compose down

POST http://localhost:5000/api/orders
GET  http://localhost:5000/api/orders
GET  http://localhost:5000/api/orders/{id}

POST http://localhost:5000/api/payments/account
GET  http://localhost:5000/api/payments/balance  
POST http://localhost:5000/api/payments/deposit
GET  http://localhost:5000/api/payments/transactions

  
