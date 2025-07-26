# BarTenderJoeApp

## Overview

**BarTenderJoeApp** is an electronic bartender demo application. It allows users to enter a product type, validates the product with a backend API, and displays appropriate messages. The app can mix drinks based on valid product types, and features a logging directive to trace user interactions (button clicks and key presses) in real time.

---

## Features

- **Instant Product Validation:**  
  As the user types a product id, the app immediately validates it via a backend API and updates messages on the UI with no extra clicks required.

- **Mix Drink Functionality:**  
  For valid product ids, users can click "Mix Drink" to get a drink name as output.

- **Real-time Activity Logging:**  
  Includes a `fascet-tracer` directive that logs button clicks and keypresses live in a textarea. This logging is decoupled from all components.

---

## Architecture & Patterns

### Frontend (Angular 16, Bootstrap, Angular Material)

- **Component-Driven UI:**  
  The main user interface is built with Angular components, particularly `BartenderJoeComponent` for product input and result display.

- **Reactive Forms & Live Validation:**  
  Input fields are bound via `ngModel` or Angular reactive forms for instant UI updates.

- **Service Pattern:**  
  All HTTP calls are handled by an injectable Angular `ProductService`, abstracting backend communication.

- **Custom Directive (fascet-tracer):**  
  Implements the observer pattern using Angular's directive system. The `fascet-tracer` directive globally listens for button clicks and key presses, logging them to a bound textarea, with **no coupling to any component**.

- **Unit Testing:**  
  Jasmine + Karma are used for robust unit testing at component, service, and directive levels.

---

### Backend (ASP.NET Core, .NET 9, C#)

- **Clean Architecture (Onion/Hexagonal):**  
  Business logic, API controllers, DTOs, and infrastructure are **separated by layers**:
    - **Presentation**: API endpoints (Controllers).
    - **Application**: Business logic and use cases.
    - **Domain**: Entities, interfaces, core models.
    - **Infrastructure**: Data access, integrations.

- **CQRS (Command Query Responsibility Segregation):**  
  Queries (like product validation) and commands (like mixing drinks) are handled with clear separation, using DTOs and handlers for each.

- **DTO (Data Transfer Object) Pattern:**  
  All API responses use DTOs to decouple backend models from API contracts and ensure clarity in the data returned to the frontend.

- **Factory/Strategy Pattern:**  
  The drink mixing logic leverages the strategy or factory pattern to generate appropriate responses for different products.

- **API Gateway (Ocelot):**  
  API requests flow through a gateway, supporting CORS and centralizing access to microservices.

- **OpenAPI/Swagger:**  
  API endpoints are fully documented and testable via Swagger UI.

- **Testability:**  
  xUnit and Moq are used for API and handler tests. WebApplicationFactory is used for integration tests.

---

## How to Run

### Prerequisites

- Node.js (v16+)
- .NET 9 SDK
- Angular CLI (v16)
- SQL Server (optional for demo)
- Chrome/Edge browser

### Frontend

```bash
cd bartender-joe-ui
npm install
ng serve
