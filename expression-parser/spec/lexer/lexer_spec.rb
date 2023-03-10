require_relative "../../lexer/lexer"

describe Lexer do
  shared_examples "single token" do |input, expect_token|
    it "returns operator token" do
      tokens = described_class.new.tokenize(input)
      expect(tokens).to eq([Token.new(token_type: expect_token, value: input)])
    end
  end

  include_examples "single token", "(", TokenType::LEFT_PARENTHESIS
  include_examples "single token", ")", TokenType::RIGHT_PARENTHESIS
  include_examples "single token", "+", TokenType::PLUS
  include_examples "single token", "-", TokenType::MINUS
  include_examples "single token", "*", TokenType::ASTERISK
  include_examples "single token", "/", TokenType::SLASH
  include_examples "single token", "12345", TokenType::NUMBER
end
