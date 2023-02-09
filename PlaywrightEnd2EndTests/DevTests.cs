using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

class Program
{
    public static async Task Main()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        await page.GotoAsync("https://www.google.com/");

        await page.GetByRole(AriaRole.Combobox, new() { Name = "Search" }).ClickAsync();

        await page.GetByRole(AriaRole.Combobox, new() { Name = "Search" }).FillAsync("Michael Schenker");

        await page.GetByRole(AriaRole.Combobox, new() { Name = "Search" }).PressAsync("Enter");

        await page.CloseAsync();

    }
}
