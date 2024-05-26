---
slug: Library Design
title: Library Design
authors: freyk
tags: [fable, library, api, design, helper]
---

# Libary Design

Siren consists of one main code base written in F#. This code base is then transpiled to JavaScript, TypeScript, Python and made accessible from C#.

# Idea 💡

During a hackathon for our research data management consortium, we were discussing ideas for visualizing graph like structures in a way that allows easy gitlab integration and can be understood and used by any level of user. The idea we pursued was to add `.md` files with mermaid graphs for an easy overview. So why not write a domain specific language for mermaid graphs to make creation of such graphs easier and more error proof. Good idea, but what programming language should we use? In our consortium we have several groups, some using JavaScript, some Python, some (us) .NET or more specifically F#. Because i already have quite some experience using [Fable][Fable], i did the mental checklist to see if it would be a good fit for this project.

- [x] *Does not need any dependencies.* Mermaid graphs, are mostly YAML, so no complex syntax.
- [x] *Does not require IO interaction.* We can simply focus on writing our mermaid graph as string and allow the user to do whatever they want with it.
- [x] *Only Fable compatible languages needed.* We are already very happy offering such a tool in Python, JavaScript and F#.

.. and thats it 🎉 So we can start developing a libary with one codebase for 4 [5] languages.

# What is Fable?

Fable is a F# to X transpiler. It started out targeting only JavaScript, using a naming reference to the popular [Babel](https://babeljs.io) JavaScript transpiler. Now Fable aims to support multiple languages, all in different states. At the time of writing, the offical Fable docs state the following:

| Language | Status | 
|---|---|
| JavaScript | Stable |
| TypeScript |	Stable| 
| Dart |	Beta| 
| Python |	Beta| 
| Rust |	Alpha| 
| PHP |	Experimental| 

## Benefits

- **Type Safety**. F# is a statically typed language, which means that the compiler can catch many errors before they even happen.
- **Lightweight Syntax**. F# has a very lightweight syntax, which makes it easy to read and write. It does not require a lot of boilerplate code and you can get right into the meat of your program.
- **Testing(?)**. Main codebase is written in F# as well as most tests. This allows us to also transpile the tests to other languages and run them there. This is a big advantage, as we can be sure that the tests are the same in all languages.

:::note[But why the question mark behind testing?]

Because we can recycle the tests, to ensure correct functionality, but we still must test if the library can be used from all supported languages without hurdles.
:::

# API Design

To make the code look and feel as native as possible in all languages, there are some things we need to consider.

## `[<AttachMembers>]`

## Overloaded Functions

## C# Compatibility

### Code generator helper

## JavaScript optional parameters

## Python/JavaScript import and Index files

# Problems

## Member Names 

- ``proplematic``
- `block.block`
- transpiled `class_`

## Docs/Native Test Maintainance

## Fable `[<NamedParameters>]` 

- with empty default object

## C# and F# Interop

# References

[Fable]: https://fable.io