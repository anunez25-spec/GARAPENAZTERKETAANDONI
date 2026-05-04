# 3POO_5 — Dokumentazio Teknikoa

## Dokumentazioa sortu eta GitHub Pages-en argitaratu

### 1. Beharrezko tresnak instalatu

```bash
# DocFX instalatu (.NET tool moduan)
dotnet tool install -g docfx
```

### 2. XML dokumentazioa sortu (konpilatzean automatikoki)

```bash
dotnet build
# → 3POO_5.xml fitxategia sortzen du automatikoki
```

### 3. DocFX exekutatu

```bash
# API metadatuak atera (yml fitxategiak sortzen ditu api/ karpetan)
docfx metadata docfx.json

# Web gunea eraiki (_site/ karpetan)
docfx build docfx.json

# Lokalean ikusi (http://localhost:8080)
docfx serve _site
```

### 4. GitHub Pages-en argitaratu

```bash
# _site/ karpetaren edukia gh-pages adarrera igo
git checkout --orphan gh-pages
git --work-tree _site add --all
git --work-tree _site commit -m "docs: DocFX dokumentazioa"
git push origin HEAD:gh-pages --force
git checkout main
```

**GitHub > Settings > Pages > Branch: `gh-pages` / `/ (root)`** aukeratu.

### Fitxategi-egitura

```
3POO_5_docs/
├── src/
│   ├── Porra.cs          ← XML doc comments
│   └── Program.cs        ← XML doc comments
├── api/
│   └── index.md
├── docfx.json            ← DocFX konfigurazioa
├── toc.yml               ← Nabigazio-egitura
├── index.md              ← Hasiera-orria
└── 3POO_5.csproj         ← GenerateDocumentationFile=true
```
