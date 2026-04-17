# 🧠 RAG Principles

This document explains the **core concepts behind Retrieval-Augmented Generation (RAG)**.

The goal is not just to build RAG, but to understand **why it works and why it fails**.

---

## 📌 What is RAG?

RAG = **Retrieve → Augment → Generate**

Instead of relying only on model knowledge, RAG:

1. Retrieves relevant documents
2. Uses them as context
3. Generates grounded answers

---

## 🔑 Core Equation

> RAG Quality =  
> **Parsing × Chunking × Retrieval × Prompting**

Each part matters. Weakness in one breaks the whole system.

---

## 🧱 1. Parsing (Document Understanding)

### What it does
Convert raw PDFs into structured text.

### Why it matters
- Determines what content is available
- Affects headings, tables, and reading order

### Common problems
- Broken paragraphs
- Missing tables
- Wrong reading order

### Insight
> If parsing is bad, everything downstream is worse.

---

## ✂️ 2. Chunking (The Most Underrated Part)

### What it does
Split documents into pieces for retrieval.

### Why it matters
The model **never sees the full document**, only chunks.

### Key tradeoffs

| Too Small | Too Large |
|----------|----------|
| Loses context | Too much noise |
| Misses answers | Lower precision |

### Strategies

- Fixed size (simple, weak)
- Heading-based (recommended)
- Semantic chunking (advanced)

### Insight
> Chunking defines what the model is allowed to know.

---

## 🔎 3. Retrieval (The Core of RAG)

### What it does
Find the most relevant chunks using embeddings.

### Steps
1. Convert query → embedding
2. Compare with chunk embeddings
3. Return top-k matches

### Failure modes

- Relevant chunk not retrieved
- Irrelevant chunk ranked higher
- Important context split across chunks

### Insight
> If retrieval fails, generation cannot recover.

---

## 🧠 4. Embeddings (Why RAG Works)

### What they are
Vector representations of meaning.

### Why they work
Similar meaning → similar vectors

Example:
- “mental health trends”
- “psychological well-being patterns”

→ close in vector space

### Limitations
- Not perfect semantic understanding
- Sensitive to wording
- Cannot infer missing context

---

## 🧾 5. Grounding (Preventing Hallucination)

### What it means
Answers must come from retrieved content.

### Rules
- Only use retrieved chunks
- Always cite sources
- Refuse if insufficient context

### Insight
> Grounding is what makes RAG trustworthy.

---

## 🤖 6. Generation (LLM Step)

### What it does
Turns retrieved content into an answer.

### Important
LLM is NOT the source of truth  
→ retrieved chunks are

### Risks
- Hallucination
- Over-generalization
- Ignoring context

---

## ⚠️ Common RAG Failure Modes

### 1. Retrieval Failure
- Wrong chunk retrieved
- Missing key chunk

### 2. Chunking Failure
- Answer split across chunks
- No chunk contains full context

### 3. Parsing Failure
- Lost tables
- Broken structure

### 4. Prompting Failure
- Model ignores instructions
- Weak grounding enforcement

---

## 🧪 How to Evaluate RAG

### NOT:
- “Does the answer sound correct?”

### YES:
- Was the correct chunk retrieved?
- Is the answer supported by evidence?
- Are citations correct?

---

## 🧠 Mental Model

Think of RAG as:
Search Engine + Reasoning Engine

- Retrieval = search engine
- LLM = reasoning engine

If search is wrong → reasoning is wrong

---

## 🔑 Key Takeaways

- RAG is NOT just calling an LLM
- Retrieval quality matters more than generation
- Chunking is one of the biggest levers
- Evaluation must be systematic
- Always separate:
  - data quality
  - retrieval quality
  - generation quality

---

## 🎯 Final Principle

> “The model is only as good as the context you give it.”

---