import nltk
from nltk.corpus import stopwords
from nltk.cluster.util import cosine_distance
import numpy as np
import networkx as nx

def sentence_similarity(sent1, sent2, stopwords):
    words1 = nltk.word_tokenize(sent1)
    words2 = nltk.word_tokenize(sent2)

    words1 = [w.lower() for w in words1 if w not in stopwords]
    words2 = [w.lower() for w in words2 if w not in stopwords]

    all_words = list(set(words1 + words2))

    vector1 = [0] * len(all_words)
    vector2 = [0] * len(all_words)

    for w in words1:
        vector1[all_words.index(w)] += 1

    for w in words2:
        vector2[all_words.index(w)] += 1

    return 1 - cosine_distance(vector1, vector2)

def build_similarity_matrix(sentences, stop_words):
    similarity_matrix = np.zeros((len(sentences), len(sentences)))

    for i in range(len(sentences)):
        for j in range(len(sentences)):
            if i != j:
                similarity_matrix[i][j] = sentence_similarity(sentences[i], sentences[j], stop_words)

    return similarity_matrix

def generate_summary(text, num_sentences=5):
    nltk.download("punkt")
    nltk.download("stopwords")

    sentences = nltk.sent_tokenize(text)
    stop_words = stopwords.words("english")
    sentence_similarity_matrix = build_similarity_matrix(sentences, stop_words)
    sentence_similarity_graph = nx.from_numpy_array(sentence_similarity_matrix)
    scores = nx.pagerank(sentence_similarity_graph)

    ranked_sentences = sorted(((scores[i], s) for i, s in enumerate(sentences)), reverse=True)
    summary = " ".join([s for _, s in ranked_sentences[:num_sentences]])

    return summary

if __name__ == "__main__":
    input_text = "Your large text here."
    summary = generate_summary(input_text)
    print(summary)
