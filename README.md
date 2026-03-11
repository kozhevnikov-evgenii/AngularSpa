# .NET 10 + Angular 21 SPA

API с методом GetAll и таблица в Angular.

## Запуск

**Терминал 1 — backend:**
```bash
dotnet run
```
API: http://localhost:5284/api/items
Swagger UI: http://localhost:5284/swagger/index.html
Swagger json: http://localhost:5284/openapi/v1.json

**Терминал 2 — frontend:**
```bash
cd ClientApp
npm install
npm start
```
Angular: http://localhost:4200 (проксирует /api на backend)
