# Vt100ParserLib

Vt100ParserLib to prosta biblioteka C# do usuwania sekwencji sterujących ANSI/VT100 (tzw. escape codes) z danych typu `byte[]`.

Może być wykorzystywana do oczyszczania logów terminalowych, danych z portów szeregowych lub strumieni zawierających formatowanie ANSI.

---

## Przykład użycia

```csharp
using Vt100ParserLib;

var parser = new Vt100Parser();

byte[] input = new byte[]
{
    0x1B, 0x5B, 0x33, 0x31, 0x6D, // ESC[31m
    (byte)'H', (byte)'e', (byte)'l', (byte)'l', (byte)'o',
    0x1B, 0x5B, 0x30, 0x6D        // ESC[0m
};

string result = parser.Parse(input);
// result == "Hello"
```

---

## Struktura repozytorium

```
Vt100ParserDemo/
├── Vt100ParserLib/             # Biblioteka
├── examples/
│   └── Vt100ParserApp/         # Przykład użycia
├── README.md
```

---

## Wymagania

- .NET 6.0 lub nowszy

---

## Licencja

MIT
