Feature: Document Conversion
    As a user
    I want to convert documents to different formats
    So that I can work with files in my preferred format

Scenario: Convert document to DOCX format
    Given I have a document with content "Sample document"
    When I convert it to "docx" format
    Then the result should be "Sample document [Converted to DOCX]"
    And the target extension should be ".docx"

Scenario: Convert document to PDF format
    Given I have a document with content "Sample document"
    When I convert it to "pdf" format
    Then the result should be "Sample document [Converted to PDF]"
    And the target extension should be ".pdf"

Scenario: Convert document to TXT format
    Given I have a document with content "Sample document"
    When I convert it to "txt" format
    Then the result should be "Sample document [Converted to TXT]"
    And the target extension should be ".txt"

Scenario Outline: Convert documents to various formats
    Given I have a document with content "<content>"
    When I convert it to "<format>" format
    Then the result should be "<expected>"
    And the target extension should be "<extension>"

Examples:
    | content     | format | expected                      | extension |
    | Hello World | docx   | Hello World [Converted to DOCX] | .docx     |
    | Hello World | pdf    | Hello World [Converted to PDF]  | .pdf      |
    | Hello World | txt    | Hello World [Converted to TXT]  | .txt      |

Scenario: Convert empty document to DOCX
    Given I have a document with content ""
    When I convert it to "docx" format
    Then the result should be " [Converted to DOCX]"

Scenario: Attempt to convert to unsupported format
    Given I have a document with content "Test content"
    When I attempt to convert it to "xml" format
    Then an ArgumentException should be thrown
    And the exception message should be "Unsupported document format"
