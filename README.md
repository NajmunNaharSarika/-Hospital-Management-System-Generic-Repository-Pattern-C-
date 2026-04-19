# 🏥 Hospital Management System — Generic Repository Pattern (C#)

> A **C# .NET** console application demonstrating the **Generic Repository Pattern** applied to a hospital domain — managing Doctors and Patients through a clean, reusable, and extensible architecture.

---

## 📋 Table of Contents

- [Overview](#overview)
- [Design Patterns Used](#design-patterns-used)
- [Project Structure](#project-structure)
- [Class Diagram](#class-diagram)
- [Key Components](#key-components)
- [Getting Started](#getting-started)
- [Sample Output](#sample-output)
- [Concepts Demonstrated](#concepts-demonstrated)

---

## Overview

This project implements a **Generic Repository Pattern** in C# to manage hospital entities (Doctors and Patients). Instead of writing separate repository logic for each entity, a single generic repository handles all CRUD operations for any type that inherits from the base class `BcPerson`. The system is designed to showcase clean OOP principles, generics, and interface-driven development.

---

## Design Patterns Used

| Pattern | Purpose |
|---|---|
| **Generic Repository** | Single reusable `GenericRepo<T>` handles all CRUD for any entity |
| **Factory Pattern** | `RepoHospital.CreateRepo<T>()` creates typed repositories on demand |
| **Dependency Injection** | `TestClass` receives `IRepoHospital` via constructor — no tight coupling |
| **Interface Segregation** | `IRepo<T>` and `IRepoHospital` keep contracts clean and minimal |

---

## Project Structure

```
CsProject/
│
├── Models/
│   ├── BcPerson.cs           # Base class — Id, Name
│   ├── Doctor.cs             # Extends BcPerson — adds Specialization
│   └── Patient.cs            # Extends BcPerson — adds Age, Disease, DoctorId
│
├── Repositories/
│   ├── IRepo.cs              # Generic CRUD interface
│   └── GenericRepo.cs        # Generic CRUD implementation
│
├── Hospital/
│   ├── IRepoHospital.cs      # Factory interface for creating repos
│   └── RepoHospital.cs       # Factory implementation
│
├── Test/
│   └── TestClass.cs          # Runs all CRUD demos for Doctor and Patient
│
└── Program.cs                # Entry point
```

---

## Class Diagram

```
BcPerson
├── int Id
└── string Name
      │
      ├──▶ Doctor
      │       └── string Specialization
      │
      └──▶ Patient
              ├── int Age
              ├── string Disease
              └── int DoctorId

IRepo<T> where T : BcPerson
├── GetAll() → List<T>
├── Get(int id) → T
├── Add(T person)
├── AddRange(IEnumerable<T>)
├── Update(T person)
└── Delete(int id)
      │
      └──▶ GenericRepo<T>   (concrete implementation)

IRepoHospital
└── CreateRepo<T>() → IRepo<T>
      │
      └──▶ RepoHospital     (returns new GenericRepo<T>)
```

---

## Key Components

### `BcPerson` — Base Model
```csharp
public class BcPerson
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```
All entities inherit from `BcPerson`, enabling the generic constraint `where T : BcPerson`.

---

### `IRepo<T>` — Generic Repository Interface
```csharp
public interface IRepo<T> where T : BcPerson
{
    List<T> GetAll();
    T Get(int id);
    void Add(T person);
    void AddRange(IEnumerable<T> persons);
    void Update(T person);
    void Delete(int id);
}
```

---

### `GenericRepo<T>` — Generic Repository Implementation
Stores data in an in-memory `IList<T>`. Provides full CRUD logic reusable for **any** entity extending `BcPerson` — no duplication needed.

---

### `IRepoHospital` — Repository Factory Interface
```csharp
public interface IRepoHospital
{
    IRepo<T> CreateRepo<T>() where T : BcPerson;
}
```
Acts as a factory that produces typed repositories, keeping object creation centralized.

---

### `TestClass` — Demo Runner
Demonstrates full CRUD operations for both `Doctor` and `Patient` using the repository, injected via constructor:
```csharp
public TestClass(IRepoHospital hospital)
{
    this.hospital = hospital;
}
```

---

## Getting Started

### Prerequisites

- [Visual Studio 2019+](https://visualstudio.microsoft.com/) or any IDE supporting **.NET Framework 4.7.2**
- .NET Framework 4.7.2 SDK

### Run the Project

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/HospitalGenericRepo.git
   cd HospitalGenericRepo
   ```

2. **Open in Visual Studio**
   - Open `CsProject.sln`
   - Build the solution (`Ctrl + Shift + B`)
   - Run (`F5` or `Ctrl + F5`)

3. **Or build via CLI**
   ```bash
   msbuild CsProject.csproj /p:Configuration=Release
   ```

---

## Sample Output

```
==================Get All==================
Id : 1, Name: Dr.Roni, Specialization : Medecin
Id : 2, Name: Dr.Golam Kibria, Specialization : Cardiology
...

============================Get==================
Id : 10, Name: Dr. Nikhin Shen, Specialization : Arthopedic

============================Update==================
Id : 1, Name: Dr.Roni, Specialization : Medecin
...
Id : 10, Name: Dr. Roton Das, Specialization : Arthopedic
...

============================Delete==================
Id : 1, Name: Dr.Roni, Specialization : Medecin
Id : 2, Name: Dr.Golam Kibria, Specialization : Cardiology
-- (Id 3 removed) --
...

===================Patient================
==================Get All==================
Id : 1, Name : Ritu Jahan, Age : 20, Disease : Illness
...
```

---

## Concepts Demonstrated

| Concept | Where Used |
|---|---|
| **Generics** (`<T>`) | `IRepo<T>`, `GenericRepo<T>`, `IRepoHospital.CreateRepo<T>()` |
| **Inheritance** | `Doctor` and `Patient` both extend `BcPerson` |
| **Generic Constraints** (`where T : BcPerson`) | Enforced on `IRepo<T>` and `GenericRepo<T>` |
| **Interface-driven design** | `IRepo<T>`, `IRepoHospital` decouple contracts from implementation |
| **Constructor Injection** | `TestClass` receives `IRepoHospital` — easy to swap implementations |
| **LINQ** | `FirstOrDefault`, `OrderBy`, `ToList`, `ForEach` throughout |
| **In-memory data store** | `IList<T>` used as a lightweight data layer |
| **Factory Method** | `RepoHospital.CreateRepo<T>()` centralizes repo creation |

---

*Built with C# · .NET Framework 4.7.2*
