@echo off
TITLE Siren Setup

ECHO Restore .NET tools
CALL dotnet tool restore

ECHO Install JavaScript Dependencies
CALL npm i

ECHO Setup Python Virtual Environment
CALL py -m venv ./.venv

ECHO Install Python Dependencies
CALL .venv\Scripts\python.exe -m pip install -U pip setuptools
CALL .venv\Scripts\python.exe -m pip install poetry
CALL .venv\Scripts\python.exe -m poetry install --no-root
ECHO DONE!