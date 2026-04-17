# 📄 BC PHO RAG System (C# + Azure Document Intelligence)

## 📌 Project Overview

This project is a **step-by-step implementation of a Retrieval-Augmented Generation (RAG) system** built in **.NET (C#)** using real-world PDF documents from the **BC Provincial Health Officer (PHO)**.
This project prioritizes understanding RAG principles over building a production system.

The goal is to deeply understand how RAG works by building each component manually:

- PDF parsing
- document structuring
- chunking
- embeddings
- retrieval
- grounded answer generation
- evaluation

The system will ingest PHO reports, convert them into structured text, and allow users to ask questions with **traceable, citation-based answers**.

---

## 🎯 Learning Goals

- Understand the full RAG pipeline end-to-end
- Learn how document structure impacts retrieval quality
- Build a modular, production-like architecture in C#
- Evaluate retrieval and answer grounding systematically

---

## 🧱 Tech Stack

### Core Application
- **.NET 10**
- **C# Console Application (v1)**

### Document Parsing
- **Azure AI Document Intelligence (Layout Model)**
- NuGet: `Azure.AI.DocumentIntelligence`

Capabilities:
- Extract text, tables, and layout structure
- Output Markdown and structured JSON
- Preserve reading order and section hierarchy

---

### Configuration & Auth
- `appsettings.json`
- Environment variables
- **AzureKeyCredential (API Key-based authentication)**

---

### Chunking & Processing
- Custom **C# chunking pipeline**
- Markdown-based section splitting
- Metadata enrichment (section, page, document)

---

### Embeddings
- **Azure OpenAI Embeddings**

Used for:
- chunk vectorization
- query vectorization

---

### Vector Storage

#### Phase 1 (Learning Mode)
- **Local JSON storage**
- Manual cosine similarity in C#

#### Phase 2 (Scalable)
- Semantic Kernel vector store abstraction
- Optional:
  - Qdrant
  - Azure AI Search
  - PostgreSQL (pgvector)

---

### Orchestration & LLM
- **Semantic Kernel**
- Azure OpenAI (or equivalent)

Used for:
- prompt orchestration
- answer generation

---

### Evaluation
- Custom evaluation framework in C#
- Fixed question set
- Retrieval + answer validation

---

## 🏗️ System Architecture

```text
PDF Documents (BC PHO)
        ↓
Azure Document Intelligence (Layout)
        ↓
Markdown + JSON Output
        ↓
Normalization (C#)
        ↓
Chunking (Heading-aware)
        ↓
Embeddings
        ↓
Vector Storage / Index
        ↓
Query Embedding
        ↓
Top-K Retrieval
        ↓
LLM Answer Generation (Grounded)
        ↓
Evaluation
```

---

