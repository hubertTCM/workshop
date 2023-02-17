require_relative "../utils"
require_relative "./token"

class Lexer
  def initialize
    @extractors = []
    @extractors.push(:extract_number_token)
  end

  def tokenize(input)
    current_index = 0
    tokens = []
    while current_index < input.length
      @extractors.each do |extractor|
        temp = method(extractor).call input, current_index
        next if temp.nil?

        current_index = temp[:next_index]
        tokens.push(temp[:token])
        break
      end
    end
    tokens
  end

  private

  def extract_number_token(input, start_index)
    value = ""
    index = start_index
    while index < input.length && Utils.digit?(input[index])
      value += input[index]
      index += 1
    end
    value.length.positive? ? { next_index: index, token: Token.new(token_type: TokenType::NUMBER, value: value) } : nil
  end
end
