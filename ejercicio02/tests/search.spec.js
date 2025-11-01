const { test, expect } = require('@playwright/test');

const TERMS = [
  'web',
  'base de datos',
  'movil',
  'inteligencia de negocios',
  'inteligencia artificial',
];

// Generamos un test por término para que Playwright genere un video por cada test.
for (const term of TERMS) {
  test(`buscar tesis: ${term}`, async ({ page }) => {
    await page.goto('https://repositorio.upt.edu.pe/', { waitUntil: 'networkidle' });

    // Intentamos localizar un campo de búsqueda con varios selectores de fallback.
    const searchSelectors = [
      'input[type="search"]',
      'input[name="search"]',
      'input[name="q"]',
      'input[placeholder*="Buscar"]',
      'input[placeholder*="buscar"]',
      '[role="search"] input',
      'form input[type="text"]',
    ];

    let input = null;
    for (const sel of searchSelectors) {
      const loc = page.locator(sel);
      if (await loc.count() > 0) {
        input = loc.first();
        break;
      }
    }

    // Fallback: role=searchbox
    if (!input) {
      try {
        const byRole = page.getByRole('searchbox');
        await byRole.waitFor({ timeout: 2000 });
        input = byRole;
      } catch (e) {
        input = null;
      }
    }

    if (!input) {
      throw new Error('No se encontró el campo de búsqueda en la página');
    }

    await input.fill(term);
    await input.press('Enter');
    // Esperamos que la página cargue resultados
    await page.waitForLoadState('networkidle');

    // Buscamos selectores comunes de resultados y validamos que hay al menos uno.
    const resultSelectors = [
      '.result',
      '.search-result',
      'article',
      'ul.results li',
      'li.search-result',
      'main a',
      '.document a',
    ];

    let hasResult = false;
    for (const sel of resultSelectors) {
      const loc = page.locator(sel);
      if (await loc.count() > 0) {
        hasResult = true;
        break;
      }
    }

    // Texto alternativo: palabras claves en la página que pueden indicar resultados
    if (!hasResult) {
      const bodyText = (await page.locator('body').innerText()).toLowerCase();
      if (bodyText.includes('resultados') || bodyText.includes('resultado') || bodyText.includes('tesis')) {
        hasResult = true;
      }
    }

    expect(hasResult, `Se esperaban resultados para la búsqueda "${term}"`).toBeTruthy();
  });
}
