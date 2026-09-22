# Subscription & Billing Engine (.NET / C#)

Egy robusztus, objektumorientált (OOP) architektúrára épülő előfizetés- és számlázáskezelő rendszer, amely valós üzleti SaaS platformok (pl. Stripe, Spotify) előfizetési logikáját és türelmi időszakait szimulálja.

## Fő funkciók & Üzleti logika

- **Dinamikus árazási motor:** Kedvezményrendszer kezelése (pl. 12 hónapos éves fizetés esetén automatikus 15%-os árengedmény).
- **Pénzügyi precizitás:** Lebegőpontos kerekítési hibák kizárása `decimal` típus használatával.
- **Türelmi idő (Grace Period) menedzsment:**
  - 1–6 nap késedelem: az előfizetés hozzáférhető marad, de `PastDue` állapotba kerül.
  - 7+ nap késedelem: a rendszer automatikusan megszünteti a jogosultságot (`Canceled`).
- **Domain-vezérelt modellek:** Enkapszuláció, `enum` állapotvezérlés és szétválasztott felelősségű osztályok.

## Projekt struktúra

```text
├── Models/              # Adat- és üzleti entitások (Plan, Customer, Subscription, Invoice)
├── Services/            # Számlázási és kalkulációs üzleti logika (BillingService)
└── Program.cs           # Szimulációs és bemutató végpont
```

## Futtatás helyi környezetben

1. Klónozd a tárolót:
   ```bash
   git clone [https://github.com/FELHASZNALONEV/subscription-billing-engine.git](https://github.com/FELHASZNALONEV/subscription-billing-engine.git)
   cd subscription-billing-engine
   ```
2. Futtasd a .NET CLI-vel:
   ```bash
   dotnet run
   ```