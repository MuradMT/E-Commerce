# E-Commerce Backend

Welcome to the E-Commerce Backend repository! This project implements the backend of an e-commerce website using C# and the .NET Core. The software architecture follows the Onion Architecture principles.

## Table of Contents

- [Features](#features)
- [Tech Stack](#tech-stack)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [Contact](#contact)

## Features

- Onion Architecture
- User Authentication and Authorization
- RESTful API
- Seperate Entity Configuration with EF Core
- Data generation with Bogus library
- Code First Approach
- Repository pattern(seperated read and write repositories)
- Unit of Work pattern
- CQRS and Mediator(with MediatR library) patterns
- Custom mapping library(with the help of AutoMapper)
- Global Exception handling(via custom middleware)

## Tech Stack

- **Language:** C#
- **Framework:** .NET Core
- **ORM:** Entity Framework Core
- **Architecture:** Onion Architecture
- **Database:** Postgres SQL
- **Version Control:** Git
- **Hosting:** GitHub
- **IDE:** Rider


### Layers

1. **Domain Layer**: Contains the core business logic and domain entities.
2. **Application Layer**: Responsible for application logic and mediates between the domain layer and the presentation layer.
3. **Infrastructure Layer**: Deals with database access, external services, and other infrastructure concerns.
4. **Presentation Layer**: Exposes the API endpoints to the outside world.

## Installation

To get a local copy up and running, follow these steps.

### Prerequisites

- .NET Core SDK
- Postgres SQL

### Clone the Repository

```bash
git clone https://github.com/your-username/e-commerce-backend.git
cd e-commerce-backend
```

### Setup the Database

- Configure your database connection string in `appsettings.json`.

### Run the Application

```bash
dotnet build
dotnet run
```

## Usage

- Access the API at `http://localhost:{your custom port-generally is 5000}/api`.

## Contributing

Contributions are what make the open-source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## Contact

- **Murad Mammadzada**
- **Email:** mammadzade03@gmail.com
