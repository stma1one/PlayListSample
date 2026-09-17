import sys
from pathlib import Path
from playwright.sync_api import sync_playwright

PROJECT_ROOT = Path(r"C:\Users\Owner\source\repos\PlayListSample")
MOCKUP_FILE = PROJECT_ROOT / "Learning" / "Mockups" / "MainPage.html"
IMAGES_DIR = PROJECT_ROOT / "Learning" / "Images"

def main():
    IMAGES_DIR.mkdir(parents=True, exist_ok=True)
    html_url = MOCKUP_FILE.as_uri()

    print(f"Loading mockup: {html_url}")
    with sync_playwright() as p:
        browser = p.chromium.launch(headless=True)
        page = browser.new_page(viewport={"width": 450, "height": 950}, device_scale_factor=2)
        page.goto(html_url, wait_until="networkidle")

        # 1. Full device frame overview
        phone_frame = page.locator("#phone-frame")
        phone_frame.screenshot(path=str(IMAGES_DIR / "MainPage-overview.png"))
        print("Captured: MainPage-overview.png")

        # 2. Hero Banner
        hero = page.locator("#hero-banner")
        hero.screenshot(path=str(IMAGES_DIR / "MainPage-hero.png"))
        print("Captured: MainPage-hero.png")

        # 3. Block 1: Single-Item Viewer & Navigation
        b1 = page.locator("#block-1")
        b1.screenshot(path=str(IMAGES_DIR / "MainPage-block1-browser.png"))
        print("Captured: MainPage-block1-browser.png")

        # 4. Block 2: Two-Way Form Input
        b2 = page.locator("#block-2")
        b2.screenshot(path=str(IMAGES_DIR / "MainPage-block2-form.png"))
        print("Captured: MainPage-block2-form.png")

        browser.close()
        print("All block screenshots captured successfully for PlayListSample!")

if __name__ == "__main__":
    main()
