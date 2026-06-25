[![Run Tests](https://github.com/julian/checkout-kata/actions/workflows/tests.yml/badge.svg)](https://github.com/julian/checkout-kata/actions/workflows/tests.yml)

# Checkout Kata

An implementation of the classic supermarket checkout kata.

The goal is to build a checkout system that:
- scans SKUs (A, B, C, D)
- applies unit pricing
- applies special offers (e.g., 3 for 130 on A, 2 for 45 on B)
- calculates a running total

This solution is built using:
- .NET 10
- xUnit for TDD
- Blazor for the UI
- MudBlazor for the components
