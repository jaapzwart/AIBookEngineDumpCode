import nltk
from nltk.tokenize import sent_tokenize, word_tokenize
from nltk.corpus import stopwords
from nltk.probability import FreqDist
import re

def analyze_and_highlight_text(input_text):
    nltk.download('punkt')
    nltk.download('stopwords')

    # Tokenize the input text into sentences and words
    sentences = sent_tokenize(input_text)
    words = word_tokenize(input_text)

    # Remove punctuation and convert to lowercase
    words_without_punctuation = [word.lower() for word in words if re.match("^[a-zA-Z]+$", word)]

    # Remove stop words
    stop_words = set(stopwords.words("english"))
    filtered_words = [word for word in words_without_punctuation if word not in stop_words]

    # Calculate word frequencies
    word_freq = FreqDist(filtered_words)

    # Define a threshold for word frequency to consider words as important
    threshold = 2  # Adjust this as needed

    # Identify important words based on frequency
    important_words = [word for word, freq in word_freq.items() if freq >= threshold]

    # Highlight important words in the text
    highlighted_text = ""

    for sentence in sentences:
        for word in word_tokenize(sentence):
            if word.lower() in important_words:
                highlighted_text += f"<span style='background-color: yellow;'>{word}</span> "
            else:
                highlighted_text += word + " "
        highlighted_text += "<br>"

    return highlighted_text

