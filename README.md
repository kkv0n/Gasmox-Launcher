# GLauncher (Gasmoxian Launcher)

Launcher for playing Crash Team Racing online on PC. It handles all the boring
stuff so you just press play: patches your clean NTSC-U CTR bin with xdelta
(Gasmoxian, OnlineCTR or your own mods), sets up DuckStation with the right
config, boots the game and connects the online client with your nickname.

Some of what it does behind the scenes:

- Runs DuckStation in portable mode inside its own folder, backing up your
  settings first and restoring them when the game closes. Your emulator stays
  exactly how it was.
- Writes volume, language and turbo counter directly into game memory through
  DuckStation's shared memory export (see the `duck_dll` project).
- Auto-updates itself, the game patch, the client and the server.
- Downloads and installs mods from the mod list.
- Server hosting tab (GServer + Radmin VPN) and launcher themes with music.

Made for the Gasmoxian community — [Discord](https://discord.gg/usjUQFpgMm).

## Requirements

- Windows (the launcher is WinForms, this is not going anywhere else)
- Visual Studio 2019 or 2022 with the **.NET desktop development** workload
- **.NET Framework 4.7.2 developer pack** (usually comes with the workload,
  otherwise grab it from Microsoft)
- C# 7.3 (nothing to install, that's just the language version the projects use)

## Building

1. Clone the repo and open `GasmoxianLauncher.sln`.
2. Right click the solution → **Restore NuGet Packages**. Packages restore into
   `third_party/` (that's what `NuGet.config` is for).
3. Build the solution. Build order is already set up: `duck_dll` and `GUpdater`
   compile before `GLauncher`.
4. Everything lands in `GasmoxianLauncher/` — exe, themes, libvlc, tools. That
   folder is 100% generated, so it's not in the repo.

First run downloads the remaining tools (rom tools, bios, etc.) from the
release pages automatically.

Heads up: always build through the .sln, not the .csproj alone — the post-build
steps depend on `$(SolutionDir)`.

More detail on every dependency (what's restored vs. what's committed and why)
in [DEPENDENCIES.md](DEPENDENCIES.md).

## Releasing

The build already drops `duck_dll.dll` next to `GLauncher.exe` (that's where the
launcher loads it from) — just make sure it goes into the update package too.
