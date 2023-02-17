require_relative "../../lexer/lexer"
describe Lexer do
  it "tokenizer" do
    tokens = described_class.new.tokenize("12345")
    expect(tokens).to eq([Token.new(token_type: TokenType::NUMBER, value: "12345")])
  end
end
