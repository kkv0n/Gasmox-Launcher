# Dependencias de GLauncher

## Cómo compilar desde un clone fresco

1. Abrir `GasmoxianLauncher.sln` en Visual Studio (.NET Framework 4.7.2).
2. Clic derecho en la solución → **Restore NuGet Packages** (los paquetes se
   restauran dentro de `third_party/`, ver `NuGet.config`).
3. Build de la solución completa. El orden ya está configurado en el .sln:
   `duck_dll` y `GUpdater` compilan antes que `GLauncher`.
4. El resultado queda en `GasmoxianLauncher/` (exe + data completa vía post-build).

## Paquetes NuGet (NO se suben al repo — se restauran solos)

Restaurados a `third_party/` según `Projects/GLauncher/packages.config`:

| Paquete | Uso | Link |
|---|---|---|
| ini-parser 2.5.2 | Lectura/escritura de settings.ini de DuckStation | https://www.nuget.org/packages/ini-parser · https://github.com/rickyah/ini-parser |
| LibVLCSharp 3.9.3 | Reproducción de música/FX del launcher | https://www.nuget.org/packages/LibVLCSharp · https://github.com/videolan/libvlcsharp |
| Newtonsoft.Json 13.0.3 | gamesettings.json, langs.json, mods.json | https://www.nuget.org/packages/Newtonsoft.Json |
| SevenZipSharp.Net45 1.0.19 | Extraer/comprimir .7z y .zip (usa 7z.dll) | https://www.nuget.org/packages/SevenZipSharp.Net45 |
| YamlDotNet 16.3.0 | Editar gamedb.yaml de DuckStation | https://www.nuget.org/packages/YamlDotNet |
| ZstdSharp.Port 0.8.4 | Descompresión zstd (GUpdater) | https://www.nuget.org/packages/ZstdSharp.Port |
| Microsoft.Bcl.AsyncInterfaces, System.* | Dependencias transitivas de los de arriba | nuget.org |

## Libs que SÍ van en el repo (custom o difíciles de conseguir)

| Carpeta | Qué es | Por qué se sube |
|---|---|---|
| `third_party/LibVLC_CUTTED/` | Build de libvlc win-x64 recortado a mano (solo los plugins que usa el launcher) | Custom, no existe en ningún lado; el post-build lo copia a `data/libvlc` |
| `third_party/sevenzip_dll/` | `7z.dll` nativo x64 que carga SevenZipSharp | Colocado a mano, versión probada; el post-build lo copia a `data/tools` |
| `third_party/xdelta.native.3.0.11.1/` | xdelta3.exe nativo (parcheo de roms) | Existe en NuGet pero es un paquete de 2019 sin mantenimiento — riesgo de desaparecer |

## Otras piezas del build

- `Projects/duck_dll/` — código fuente de la DLL de shared memory con DuckStation.
  La DLL compilada NO se sube (la genera el propio .sln). **Al armar un release,
  duck_dll.dll debe ir junto a GLauncher.exe** (el runtime la carga desde ahí).
- `Launcher_themes/` — assets fuente de los temas del launcher (se copian a
  `data/themes` en el post-build). Editar aquí, no en la carpeta de build.
- Herramientas de rom (dumpsxiso, mkpsxiso, bigtool, etc.) — no viven en el repo:
  el launcher las descarga en runtime (`essential.zip` desde GitHub Releases).
