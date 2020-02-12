Feature: Suppliers - Appear On Preview
	As a Supplier
	I want to view the Preview Page
	So I can ensure my solution is previewed correctly

Background: 
	Given a solution has been created with all data complete

Scenario Outline: Appear on Preview - Hosting Types	
	When a User previews the Marketing Page
	Then Summary will be presented in <HostingType> on the Preview of the Marketing Page
	And The <HostingType> section contains This Solution requires a HSCN/N3 connection on the preview of the marketing page

	Examples:
	| HostingType   |
	| Hybrid        |
	| On premise    |
	| Private cloud |
	| Public cloud  |

Scenario Outline: Appear on Preview - Client Application Types
	When a User previews the Marketing Page
	Then <SubSection> will be presented in <Section> on the Preview of the Marketing Page

	Examples:
	| Section                 | SubSection                                          |
	| Browser based           | Supported browser types                             |
	| Browser based           | Mobile responsive                                   |
	| Browser based           | Mobile first approach                               |
	| Browser based           | Plug-ins or extensions required                     |
	| Browser based           | Additional information about plug-ins or extensions |
	| Browser based           | Minimum connection speed                            |
	| Browser based           | Screen resolution and aspect ratio                  |
	| Browser based           | Hardware requirements                               |
	| Browser based           | Additional information                              |
	| Native mobile or tablet | Supported operating systems                         |
	| Native mobile or tablet | Description of supported operating systems          |
	| Native mobile or tablet | Mobile first approach                               |
	| Native mobile or tablet | Minimum connection speed                            |
	| Native mobile or tablet | Connection types supported                          |
	| Native mobile or tablet | Connection requirements                             |
	| Native mobile or tablet | Memory size                                         |
	| Native mobile or tablet | Storage space                                       |
	| Native mobile or tablet | Third-party components                              |
	| Native mobile or tablet | Device capabilities                                 |
	| Native mobile or tablet | Hardware requirements                               |
	| Native mobile or tablet | Additional information                              |
	| Native desktop          | Supported operating systems                         |
	| Native desktop          | Minimum connection speed                            |
	| Native desktop          | Memory size                                         |
	| Native desktop          | Storage space                                       |
	| Native desktop          | Processing power                                    |
	| Native desktop          | Screen resolution and aspect ratio                  |
	| Native desktop          | Third-party components                              |
	| Native desktop          | Device capabilities                                 |
	| Native desktop          | Hardware requirements                               |
	| Native desktop          | Additional information                              | 

Scenario Outline: Appear on Preview - Main Sections
	When a User previews the Marketing Page
	Then the <section> section is presented

	Examples: 
	| section                   |
	| Description               |
	| Features                  |
	| Client application type   |
	| Roadmap                   |
	| Hosting type              |
	| Contact details           |
	| About supplier            |
	| Integrations              |
	| Implementation timescales |