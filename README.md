# Rockstar.Dotnet - An initial implementation of the Rockstar language
# Hot in the City edition.

This version of Rockstar is capable of running the samples at https://github.com/dylanbeattie/rockstar with a couple of small modifications.

## Differences from the rockstar specification.
- Does not use DEC64 for numbers, use the .net decimal type instead.
- `While`, `Until` always need an `End` or `And around we go` statement.

## Issues caused by specification ambiguity
- Keywords are case insensitive, but variables are not.
- Is, was, Were are aliased in all cases, not just poetic literal assignment.
