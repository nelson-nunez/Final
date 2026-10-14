<p align="center">
  <img src="assets/readme/hero.svg" alt="SiAP: gestión de consultorio médico en C# y .NET 8" width="100%">
</p>

<p align="center">
  <img alt=".NET 8" src="https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white">
  <img alt="C#" src="https://img.shields.io/badge/C%23-WinForms-239120?logo=csharp&logoColor=white">
  <img alt="Plataforma" src="https://img.shields.io/badge/Windows-10%2B-0078D6?logo=windows&logoColor=white">
  <img alt="Trabajo Final UAI" src="https://img.shields.io/badge/UAI-Trabajo%20Final-0f766e">
</p>

**SiAP** es una aplicación de escritorio para Windows que reúne en un solo lugar el trabajo diario de un consultorio: agenda de médicos, turnos de pacientes, historias clínicas, recetas, facturación y cobros. Es el Trabajo Final de la carrera en la UAI.

## Qué incluye

| | Módulo | Qué resuelve |
|---|---|---|
| 📅 | **Agenda y turnos** | Agenda por médico, turnos de pacientes e impresión de turnos en PDF. |
| 🩺 | **Historias y consultas** | Historia clínica del paciente y registro de cada consulta. |
| 💊 | **Recetas y certificados** | Emisión en PDF, y pantalla para renovar recetas. |
| 💳 | **Cobros y facturas** | Cobros por forma de pago y facturas en PDF. |
| 📊 | **Reportes** | Dashboard con gráficos de ingresos mensuales e ingresos por especialidad. |
| 🔐 | **Usuarios y permisos** | Login, roles y permisos simples o compuestos; el menú se arma según los permisos del usuario. |
| 💾 | **Respaldos y logs** | Respaldos de la base de datos y registro de actividad. |

> [!NOTE]
> TODO: agregar capturas de pantalla en `assets/screenshots/` (login, agenda y dashboard) y mostrarlas aquí. El repositorio todavía no tiene ninguna.

## Arquitectura

<p align="center">
  <img src="assets/readme/arquitectura.svg" alt="Capas de SiAP: UI, BLL, MPP, DAL y archivos XML, con BE y Abstracciones transversales" width="100%">
</p>

La solución `SiAP/SiAP.sln` está organizada en capas:

| Proyecto | Responsabilidad |
|---|---|
| `SiAP.UI` | Formularios WinForms, controles de usuario, extensiones y generadores de PDF. Punto de entrada: `Form_Menu`. |
| `SiAP.BLL` | Lógica de negocio por entidad (`BLL_Turno`, `BLL_Receta`, …), seguridad y encriptación. |
| `SiAP.MPP` | Mappers que convierten filas de datos en entidades y al revés. |
| `SiAP.DAL` | Acceso a datos sobre archivos XML (`AccesoXML`). |
| `SiAP.BE` | Entidades: `Paciente`, `Medico`, `Turno`, `Receta`, `Factura`, `Usuario`, `Permiso`, etc. |
| `SiAP.Abstracciones` | Interfaces compartidas (`IBLL`, `IMapper`, `ILogger`, `IEncriptacion`). |

## Instalación

**Opción 1: instalador.** Ejecutá `SiAP3.msi`, que está en la raíz del repositorio.

**Opción 2: desde el código.** Necesitás Windows y el [SDK de .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0).

```bash
git clone https://github.com/nelson-nunez/Final.git
cd Final/SiAP
dotnet run --project SiAP/SiAP.UI.csproj
```

También podés abrir `SiAP/SiAP.sln` en Visual Studio 2022 y ejecutar `SiAP.UI`.

> [!WARNING]
> La carpeta `SiAP/BaseDatos/` (datos en XML) está excluida por `.gitignore`. Una copia nueva del repositorio no trae datos de ejemplo. TODO: documentar cómo generar la base inicial y las credenciales de prueba.

## Tecnologías

- C# con .NET 8 y Windows Forms
- [PDFsharp](https://www.pdfsharp.net/) 6.0 para recetas, certificados, facturas y turnos
- [ScottPlot](https://scottplot.net/) 4.1 para los gráficos del dashboard
- XML (DataSet) como almacenamiento
- Triple DES y HMAC-SHA1 para la protección de datos sensibles

<details>
<summary><strong>Estructura del repositorio</strong></summary>

```text
.
├── SiAP3.msi            # instalador
├── assets/readme/       # imágenes del README
└── SiAP/
    ├── SiAP.sln
    ├── SiAP/            # UI (WinForms)
    ├── SiAP.BLL/        # reglas de negocio
    ├── SiAP.MPP/        # mapeo
    ├── SiAP.DAL/        # acceso a XML
    ├── SiAP.BE/         # entidades
    └── SiAP.Abstracciones/
```

</details>

## Autor

Nelson Núñez, Trabajo Final, UAI.

## Licencia

TODO: el repositorio no incluye un archivo de licencia. Agregá uno (por ejemplo MIT) si querés definir cómo se puede reutilizar el código.
