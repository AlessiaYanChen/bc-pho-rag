# Codex Guidelines

This file defines how I should work on this project.

## Purpose

Support a learning-first RAG build in C# by making the system easy to understand, inspect, and evolve step by step.

## Default Working Style

- Prefer clarity over speed.
- Keep solutions simple, explicit, and easy to inspect on disk.
- Make one concept visible at a time instead of hiding logic behind abstraction too early.
- Treat retrieval quality as the primary concern before spending effort on generation quality.
- Explain tradeoffs clearly when proposing changes.
- Preserve a clean mental model of the pipeline: parse, normalize, chunk, embed, retrieve, answer, evaluate.

---

## Hard Constraints

- Do not optimize for production before the learning goal is satisfied.
- Do not introduce a vector database in Phase 1.
- Do not introduce Python.
- Do not introduce Docling.
- Do not add unnecessary infrastructure, frameworks, or background services.
- Do not collapse multiple pipeline stages into one opaque step if that reduces understanding.
- Do not improve prompts as a substitute for weak retrieval.
- Do not assume a more complex architecture is better.

---

## Implementation Approach

- Start with the smallest version that demonstrates the concept correctly.
- Keep pipeline stages separable so outputs can be inspected independently.
- Prefer deterministic, debuggable transformations over clever heuristics.
- Save intermediate artifacts where useful for learning, debugging, and evaluation.
- Define internal models before wiring external services around them.
- Add abstractions only when they clarify boundaries or reduce confusion.
- Favor straightforward local JSON artifacts in Phase 1.
- Build retrieval inspection before answer generation.
- Add evaluation early enough to guide decisions, not only at the end.

---

## Decision Rules

- When choosing between flexibility and transparency, prefer transparency.
- When choosing between feature breadth and retrieval quality, prefer retrieval quality.
- When choosing between elegant architecture and visible data flow, prefer visible data flow.
- When uncertain, ask: "Will this make the RAG pipeline easier or harder to understand?"

---

## Code Expectations

- Keep code modular, but not fragmented without reason.
- Use names that map directly to RAG concepts.
- Make data contracts explicit.
- Preserve metadata needed for traceability, especially document, section, and page references.
- Keep console output useful for inspecting parsing, chunking, and retrieval behavior.
- Add comments only where they clarify a non-obvious decision or transformation.

---

## Evaluation Mindset

- Validate retrieval before validating answer fluency.
- Inspect failure modes directly.
- Treat missing or wrong retrieval as the first problem to solve.
- Require grounded answers with clear citations.
- Prefer small, repeatable evaluation sets over vague subjective testing.

---

## Git & Commit Discipline

Apply these rules **only when the user explicitly requests commits or when committing is part of the task**.

### Commit Scope

- Each commit should represent one logical unit of work
- Do not mix unrelated changes in one commit
- Do not commit incomplete or partially working features unless explicitly instructed

---

### Commit Message Format

Use:

```
<type>: <description>
```

Types:
- feat: new functionality
- fix: bug fix
- refactor: code restructuring
- docs: documentation updates

---

### Commit Rules

- When code changes are included, verify the build or runtime as appropriate
- When working on docs or data artifacts, validate those outputs instead of forcing a build
- Make one commit per completed task when committing is requested
- Do not create trivial or empty commits
- Keep commits aligned with the current roadmap phase

---

### Post-Commit Behavior

After each requested commit, provide:

- What was implemented
- Which RAG concept it relates to
- What was verified
- What remains uncertain or needs validation

---

## Execution Flow

For each task:

1. Read the relevant docs and existing code
2. Identify which pipeline stage the change affects
3. Implement the smallest correct version for the current phase
4. Verify outputs at the appropriate level:
   - build/runtime checks for code
   - artifact checks for parsed data, chunks, or docs
5. Summarize:
   - what changed
   - what was verified
   - what remains uncertain
6. Commit **only if requested or explicitly part of the task**

---

## Final Principle

> Understanding the system is more important than extending the system.

Every change should make the RAG pipeline:
- more visible
- more explainable
- easier to reason about