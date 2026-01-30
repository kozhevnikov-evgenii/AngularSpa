# .NET 10 + Angular 21 SPA

Простой проект для лайв-кодинга: API с методом GetAll и таблица в Angular.

## Запуск

**Терминал 1 — backend:**
```bash
dotnet run
```
API: http://localhost:5284/api/items

**Терминал 2 — frontend:**
```bash
cd ClientApp
npm install
npm start
```
Angular: http://localhost:4200 (проксирует /api на backend)

## Структура

- **Backend:** `Controllers/ItemsController.cs` — метод `GetAll()` возвращает список элементов
- **Frontend:** `ClientApp/src/app/` — сервис вызывает API, таблица в `app.html`
