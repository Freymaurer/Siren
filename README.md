# Siren

Siren is a simple DSL for creating [Mermaid](https://mermaid.js.org) graphs YAML.

Have a look at the docs here:

* [Docs](https://freymaurer.github.io/Siren/)
* [Blog post](https://freymaurer.github.io/Siren/blog/Library%20Design)

<table>
  <thead>
    <tr>
      <th>Latest Release</th>
      <th>Downloads</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <a href="https://pypi.org/project/siren-dsl/">
          <img src="https://img.shields.io/pypi/v/siren-dsl?logo=pypi" alt="latest release" />
        </a>
      </td>
      <td>
        <a href="https://pepy.tech/project/siren-dsl">
          <img src="https://pepy.tech/badge/siren-dsl" alt="downloads" />
        </a>
      </td>
    </tr>
    <!-- js package -->
    <tr>
      <td>
        <a href="https://www.npmjs.com/package/siren-dsl">
          <img src="https://img.shields.io/npm/v/siren-dsl?logo=npm" alt="latest release" />
        </a>
      </td>
      <td>
        <a href="https://www.npmjs.com/package/siren-dsl">
          <img src="https://img.shields.io/npm/dt/siren-dsl.svg" alt="downloads" />
        </a>
      </td>
    </tr>
    <!-- f# nuget package -->
    <tr>
      <td>
        <a href="https://www.nuget.org/packages/Siren/">
          <img src="https://img.shields.io/nuget/v/Siren?logo=nuget" alt="latest release" />
        </a>
      </td>
      <td>
        <a href="https://www.nuget.org/packages/Siren/">
          <img src="https://img.shields.io/nuget/dt/Siren.svg" alt="downloads" />
        </a>
      </td>
      <!-- c# nuget package "Siren.Sea" -->
    </tr>
    <tr>
      <td>
        <a href="https://www.nuget.org/packages/Siren.Sea/">
          <img src="https://img.shields.io/nuget/v/Siren.Sea?logo=nuget" alt="latest release" />
        </a>
      </td>
      <td>
        <a href="https://www.nuget.org/packages/Siren.Sea/">
          <img src="https://img.shields.io/nuget/dt/Siren.Sea.svg" alt="downloads" />
        </a>
      </td>
    </tr>
  </tbody>

</table>


---
> if you are interested in creating a Fable library like this on your own you can use the template [Fable.Multiverse](https://github.com/Freymaurer/Fable.Multiverse)!
---
## Contribution

If you have any ideas on how to improve the library, please feel free to contribute! The best way to get in contact is using the issues! 

---
## Local Development

### Requirements

Because this library targets multiple programming languages we need to support all of them:

- [nodejs and npm](https://nodejs.org/en/download)
    - verify with `node --version` (Tested with v20.10.0)
    - verify with `npm --version` (Tested with v9.2.0)
- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
    - verify with `dotnet --version` (Tested with 8.0.205)
- [Python](https://www.python.org/downloads/)
    - verify with `py --version` (Tested with 3.11.9, known to work only for >=3.11)

### Setup

This needs to be done on a fresh download once. Paths for python venv executable might be different depending on the OS.

1. `dotnet tool restore`
2. `npm install`
3. `py -m venv ./.venv`
4. `.\.venv\Scripts\Activate.ps1`
5. `python -m pip install -U pip setuptools`
6. `python -m pip install poetry`
7. `python -m poetry install --no-root`

### Testing

First activate python virtual environment (`.\.venv\Scripts\Activate.ps1`).

`.\build.cmd test`

*or specify target*

`.\build.cmd test [f#, c#, js [native], py [native]]`

### Publish

Requires API keys for Nuget and PyPi. 

The following command will run all tests, bundle and then start publishing!

`.\build.cmd publish full`

*or only publish specific targets, without test and bundle*

`.\build.cmd publish [npm, pypi, nuget]`
