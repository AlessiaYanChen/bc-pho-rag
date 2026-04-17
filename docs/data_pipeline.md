# 🔄 Data Pipeline

This pipeline describes the full flow of a Retrieval-Augmented Generation (RAG) system.

---

## 1. Document Ingestion
- Input: PDF files (PHO reports)
- Stored in: `/data/raw`

---

## 2. Document Parsing
- Send PDF to Azure Layout API
- Output:
  - Markdown (`.md`)
  - Structured JSON (`.json`)

Stored in:

```text
/data/parsed/{document}/
```

### 3. Normalization
Convert Azure output into internal format:

- Document metadata
- Section hierarchy
- Page mapping
- Raw Markdown

### 4. Chunking
Split documents into retrieval units.
Strategy:
- Split by headings (H1, H2)
- Keep tables with relevant sections
- Maintain semantic grouping

Each chunk includes:
- Content
- Section path
- Page numbers
- Document reference

### 5. Embedding
Convert text into vector representations.
- Generate embeddings for:
  - document chunks
  - user queries
Embeddings enable semantic similarity search.

### 6. Indexing
- Store chunks + embeddings into local JSON files

### 7. Retrieval
When user asks a question:
1. Embed the query
2. Compare query embedding with chunk embeddings
3. Retrieve top-k most similar chunks
4. Rank results

> Top-k = the number of most relevant chunks returned (e.g., top 3 or top 5)

> Retrieval quality is the most critical step in RAG.
> If the correct chunk is not retrieved, the system will fail regardless of LLM quality.

### 8. Context Preparation
Prepare retrieved content for the LLM:
- Combine retrieved chunks
- Remove duplicates
- Preserve source metadata (section, page)
- Format context for prompt input

### 9. Answer Generation
Generate a grounded answer using retrieved context.
Rules:
- Only use retrieved chunks
- Include citations (section/page)
- Do not fabricate information
- Refuse if context is insufficient

### 10. Evaluation
Evaluate system performance using predefined questions:
- Was the correct chunk retrieved?
- Is the answer supported by evidence?
- Are citations accurate?
- Does the system avoid hallucination?

---