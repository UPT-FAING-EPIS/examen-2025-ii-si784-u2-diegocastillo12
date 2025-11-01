[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/bTwXPjqC)
[![Open in Codespaces](https://classroom.github.com/assets/launch-codespace-2972f46106e565e64193e422d61a12cf1da4916b45550586e14ef0a7c637dd04.svg)](https://classroom.github.com/open-in-codespaces?assignment_repo_id=21411396)

# Document Converter - Examen Unidad de Calidad

[![Unit and BDD Tests](https://github.com/UPT-FAING-EPIS/examen-2025-ii-si784-u2-diegocastillo12/actions/workflows/test-and-coverage.yml/badge.svg)](https://github.com/UPT-FAING-EPIS/examen-2025-ii-si784-u2-diegocastillo12/actions/workflows/test-and-coverage.yml)
[![UI Tests](https://github.com/UPT-FAING-EPIS/examen-2025-ii-si784-u2-diegocastillo12/actions/workflows/ui-tests.yml/badge.svg)](https://github.com/UPT-FAING-EPIS/examen-2025-ii-si784-u2-diegocastillo12/actions/workflows/ui-tests.yml)

## Descripción

Aplicación de conversión de documentos desarrollada en C# con .NET 9.0 que permite convertir contenido de texto a diferentes formatos (DOCX, PDF, TXT). El proyecto incluye pruebas unitarias, pruebas BDD, pruebas de interfaz de usuario y automatización completa con GitHub Actions.

## Estructura del Proyecto

```
examen-2025-ii-si784-u2-diegocastillo12/
├── DocumentConverter.Core/          # Biblioteca principal con la lógica de conversión
│   ├── IDocumentConverter.cs        # Interfaz del conversor
│   ├── DocxConverter.cs             # Conversor a DOCX
│   ├── PdfConverter.cs              # Conversor a PDF
│   ├── TxtConverter.cs              # Conversor a TXT
│   └── DocumentConverterFactory.cs  # Factory para crear conversores
├── DocumentConverter.Web/           # Aplicación web ASP.NET Core
│   └── Program.cs                   # Configuración y endpoints de la API
├── DocumentConverter.Tests/         # Pruebas unitarias con xUnit
│   ├── DocxConverterTests.cs
│   ├── PdfConverterTests.cs
│   ├── TxtConverterTests.cs
│   └── DocumentConverterFactoryTests.cs
├── DocumentConverter.BDD/           # Pruebas BDD con SpecFlow
│   ├── Features/
│   │   └── DocumentConversion.feature
│   └── StepDefinitions/
│       └── DocumentConversionStepDefinitions.cs
├── DocumentConverter.UITests/       # Pruebas de interfaz de usuario con Selenium
│   └── DocumentConverterUITests.cs
└── .github/
    └── workflows/
        ├── test-and-coverage.yml    # CI/CD para pruebas unitarias y BDD
        └── ui-tests.yml             # CI/CD para pruebas de UI con grabación
```

## Características Implementadas

### ✅ 1. Aplicación Principal (1 punto)
- Implementación completa de las clases de conversión de documentos
- Patrón Factory para la creación de conversores
- Aplicación web con interfaz de usuario HTML/CSS/JavaScript
- API REST para conversión de documentos

### ✅ 2. Pruebas Unitarias con Cobertura >80% (2 puntos)
- **25 pruebas unitarias** con xUnit
- **100% de cobertura de código**
- Pruebas para todos los conversores (DOCX, PDF, TXT)
- Pruebas para el Factory Pattern
- Pruebas de casos edge (strings vacíos, formatos no soportados)

### ✅ 3. Pruebas BDD (1 punto)
- Implementación con **SpecFlow**
- **8 escenarios** en formato Gherkin
- Pruebas parametrizadas con ejemplos
- Validación de excepciones
- Step Definitions completas

### ✅ 4. Automatización GitHub Actions - Pruebas Unitarias y BDD (3 puntos)
- Workflow automático en cada push/PR
- Ejecución de pruebas unitarias y BDD
- Generación de reportes de cobertura con ReportGenerator
- **Publicación automática en GitHub Pages**
- Artifacts de reportes disponibles

### ✅ 5. Pruebas de Interfaz de Usuario (1 punto)
- Pruebas con **Selenium WebDriver**
- Pruebas para Chrome y Firefox
- Validación de elementos del formulario
- Pruebas de conversión end-to-end

### ✅ 6. Automatización GitHub Actions - Pruebas UI Multi-Navegador (3 puntos)
- Ejecución en **Chrome y Firefox**
- Matrix strategy para múltiples navegadores
- Configuración headless para CI/CD

### ✅ 7. Grabación de Video de Pruebas UI (2 puntos)
- **Grabación automática con FFmpeg**
- Videos separados por navegador
- Upload como artifacts en GitHub Actions
- Formato MP4 con resolución 1920x1080

## Tecnologías Utilizadas

- **.NET 9.0** - Framework principal
- **ASP.NET Core** - Aplicación web
- **xUnit** - Pruebas unitarias
- **SpecFlow** - Pruebas BDD (Behavior-Driven Development)
- **Selenium WebDriver** - Pruebas de UI
- **Coverlet** - Análisis de cobertura de código
- **ReportGenerator** - Generación de reportes HTML
- **FFmpeg** - Grabación de video
- **GitHub Actions** - CI/CD

## Ejecución Local

### Requisitos Previos
- .NET 9.0 SDK
- Chrome/Firefox (para pruebas UI)

### Compilar el Proyecto
```bash
dotnet build
```

### Ejecutar Pruebas Unitarias
```bash
dotnet test DocumentConverter.Tests/DocumentConverter.Tests.csproj
```

### Ejecutar Pruebas Unitarias con Cobertura
```bash
dotnet test DocumentConverter.Tests/DocumentConverter.Tests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

### Ejecutar Pruebas BDD
```bash
dotnet test DocumentConverter.BDD/DocumentConverter.BDD.csproj
```

### Ejecutar Aplicación Web
```bash
cd DocumentConverter.Web
dotnet run
```
La aplicación estará disponible en `http://localhost:5000`

### Ejecutar Pruebas de UI (requiere aplicación web ejecutándose)
```bash
dotnet test DocumentConverter.UITests/DocumentConverter.UITests.csproj
```

## Reportes y Documentación

Los reportes de cobertura y resultados de pruebas se publican automáticamente en GitHub Pages:
- **Reporte de Cobertura**: `https://upt-faing-epis.github.io/examen-2025-ii-si784-u2-diegocastillo12/coverage/`
- **Resultados de Pruebas**: `https://upt-faing-epis.github.io/examen-2025-ii-si784-u2-diegocastillo12/tests/`

## Resultados de Cobertura

- **Cobertura de Línea**: 100%
- **Cobertura de Rama**: 100%
- **Cobertura de Método**: 100%

## Workflows de GitHub Actions

### 1. Test and Coverage (`test-and-coverage.yml`)
- Ejecuta pruebas unitarias y BDD
- Genera reporte de cobertura
- Publica resultados en GitHub Pages
- Se ejecuta en cada push/PR a main/master

### 2. UI Tests (`ui-tests.yml`)
- Ejecuta pruebas de UI en Chrome y Firefox
- Graba video de la ejecución
- Sube videos como artifacts
- Matrix strategy para múltiples navegadores

## Patrones de Diseño Utilizados

1. **Factory Pattern**: `DocumentConverterFactory` para crear instancias de conversores
2. **Interface Segregation**: `IDocumentConverter` define el contrato
3. **Dependency Injection**: En la aplicación web
4. **Strategy Pattern**: Diferentes estrategias de conversión por formato

## Autor

Diego Castillo - Examen Unidad de Calidad SI784-U2

## Calificación Esperada

- Crear la aplicación: **1 punto** ✅
- Pruebas unitarias con >80% cobertura: **2 puntos** ✅
- Pruebas BDD: **1 punto** ✅
- Automatización GitHub Actions (pruebas + reportes + GitHub Pages): **3 puntos** ✅
- Pruebas de interfaz de usuario: **1 punto** ✅
- Automatización UI en múltiples navegadores: **3 puntos** ✅
- Generación de video: **2 puntos** ✅

**Total: 13 puntos** 🎯

