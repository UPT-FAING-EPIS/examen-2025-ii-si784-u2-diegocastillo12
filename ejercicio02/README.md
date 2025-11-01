# Pruebas UI - Repositorio UPT

## 📋 Descripción

Proyecto de pruebas automatizadas de interfaz de usuario para el **Repositorio de la UPT** (https://repositorio.upt.edu.pe/).

### Historia de Usuario

**Como** estudiante de la UPT  
**Quiero** encontrar tesis de tecnología en el Repositorio de la UPT  
**Para** investigar sobre tecnologías recientes y tener referencias

### Criterio de Aceptación (CA1)

**Dado que** como estudiante tengo acceso al repositorio de trabajos académicos de la UPT  
**Cuando** realizo una búsqueda de tecnología (web / base de datos / móvil / inteligencia de negocios / inteligencia artificial)  
**Entonces** espero tener uno o muchos resultados

---

## 🚀 Características

✅ Pruebas automatizadas con **Playwright**  
✅ Ejecución en **múltiples navegadores** (Chromium y Firefox)  
✅ **Grabación de video** de cada prueba  
✅ Integración continua con **GitHub Actions**  
✅ Búsqueda de 5 términos tecnológicos diferentes

---

## 📦 Requisitos

- Node.js 18 o superior
- npm 7 o superior

---

## 🔧 Instalación

```bash
# Instalar dependencias
npm install

# Instalar navegadores de Playwright
npx playwright install
```

---

## ▶️ Ejecución Local

### Ejecutar todas las pruebas

```bash
npm test
```

### Ejecutar en un navegador específico

```bash
# Solo Chromium
npx playwright test --project=chromium

# Solo Firefox
npx playwright test --project=firefox
```

### Ver el reporte HTML

```bash
npm run test:report
```

### Ver los videos generados

Los videos se guardan en `test-results/` después de cada ejecución.

---

## 🤖 CI/CD - GitHub Actions

El workflow `.github/workflows/ci.yml` se ejecuta automáticamente en cada push o pull request.

### Características del CI:

- Ejecuta las pruebas en **Chromium** y **Firefox** en paralelo
- Instala dependencias y navegadores automáticamente
- **Genera videos** de todas las pruebas
- Sube los videos como **artefactos** (disponibles por 90 días)

### Ver videos en GitHub Actions:

1. Ve a la pestaña **Actions** en tu repositorio
2. Selecciona el workflow ejecutado
3. En la sección **Artifacts**, descarga:
   - `videos-chromium`
   - `videos-firefox`

---

## 📂 Estructura del Proyecto

```
ejercicio02/
├── .github/
│   └── workflows/
│       └── ci.yml              # Workflow de GitHub Actions
├── tests/
│   └── search.spec.js          # Tests de búsqueda
├── test-results/               # Videos y resultados (gitignored)
├── playwright.config.js        # Configuración de Playwright
├── package.json                # Dependencias del proyecto
├── .gitignore
└── README.md
```

---

## 🧪 Tests Implementados

### `search.spec.js`

Prueba la búsqueda de los siguientes términos:

1. **web**
2. **base de datos**
3. **móvil**
4. **inteligencia de negocios**
5. **inteligencia artificial**

Cada test:
- Navega a https://repositorio.upt.edu.pe/
- Busca el campo de búsqueda (con múltiples selectores de fallback)
- Ingresa el término y presiona Enter
- Verifica que existan resultados
- **Graba un video** de la ejecución

---

## 🎥 Videos

La configuración de Playwright está ajustada para:
- Grabar video de **todas** las pruebas (`video: 'on'`)
- Resolución: 1280x720
- Formato: WebM
- Ubicación: `test-results/<test-name>/video.webm`

---

## 🔍 Selectores Implementados

Los tests utilizan múltiples estrategias de fallback para encontrar elementos:

### Campo de búsqueda:
- `input[type="search"]`
- `input[name="search"]`
- `input[name="q"]`
- `input[placeholder*="Buscar"]`
- `[role="search"] input`
- `getByRole('searchbox')`

### Resultados:
- `.result`, `.search-result`
- `article`, `ul.results li`
- `main a`, `.document a`
- Análisis de texto del body

---

## 📊 Mejoras Futuras

- [ ] Agregar pruebas de filtros avanzados
- [ ] Validar contenido específico de cada resultado
- [ ] Agregar pruebas de paginación
- [ ] Implementar tests de accesibilidad
- [ ] Agregar WebKit (Safari) como tercer navegador
- [ ] Implementar trace viewer para debugging
- [ ] Agregar screenshots en caso de falla

---

## 👤 Autor

Estudiante de la UPT - Curso de Calidad de Software

---

## 📄 Licencia

Este proyecto es parte de un examen académico.
