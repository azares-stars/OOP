# SortTimerWithReflection

Това е C# конзолно приложение, което демонстрира:

- Генериране на списък от обекти `Person` със случайни имена и възраст.
- Сортиране с помощта на два компаратора: по възраст и по име.
- Измерване на времето за сортиране.
- Извеждане на информация за типовете чрез Reflection.

## Изисквания

- [.NET SDK 6.0 или по-нова версия](https://dotnet.microsoft.com/download)
- Текстов редактор или IDE по избор (напр. Visual Studio Code, Visual Studio, Rider)

## Стъпки за компилиране и стартиране

1. **Клониране на репото или копиране на файловете:**

   ```bash
   git clone <url на репото>
   cd SortTimerWithReflection



## OUTPUT НА ПРОГРАМАТА

Сортиране с AgeComparer отне 1.9363 ms.
Сортиране с NameComparer отне 2.1457 ms.

Информация чрез Reflection:
Тип: SortTimerWithReflection.AgeComparer
Сборка: SortTimerWithReflection
Методи:
- Compare
Имплементирани интерфейси:
- System.Collections.Generic.IComparer`1[SortTimerWithReflection.Person]

Тип: SortTimerWithReflection.NameComparer
Сборка: SortTimerWithReflection
Методи:
- Compare
Имплементирани интерфейси:
- System.Collections.Generic.IComparer`1[SortTimerWithReflection.Person]
