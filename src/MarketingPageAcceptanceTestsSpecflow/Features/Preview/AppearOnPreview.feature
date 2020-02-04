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
	| Section                 | SubSection                                             |
	| Browser based           | Browsers supported                                     |
	| Browser based           | Minimum connection speed required                      |
	| Browser based           | Recommended desktop aspect ratio and screen resolution |
	| Browser based           | Hardware requirements                                  |
	| Browser based           | Additional information                                 |
	| Browser based           | Mobile first                                           |
	| Browser based           | Plug-ins or extensions                                 |
	| Native mobile or tablet | Additional information about connection types          |
	| Native mobile or tablet | Hardware requirements                                  |
	| Native mobile or tablet | Additional information                                 |
	| Native mobile or tablet | Minimum memory requirement                             |
	| Native mobile or tablet | Additional storage requirements                        |
	| Native mobile or tablet | Designed with a mobile first approach                  |
	| Native mobile or tablet | Supported operating systems                            |
	| Native mobile or tablet | Third party components required                        |
	| Native mobile or tablet | Device capabilities required                           |
	| Native desktop          | Minimum connection speed required                      |
	| Native desktop          | Hardware requirements                                  |
	| Native desktop          | Additional information                                 |
	| Native desktop          | Additional storage requirements                        |
	| Native desktop          | Minimum memory requirement                             |
	| Native desktop          | Minimum necessary CPU power                            |
	| Native desktop          | Recommended desktop aspect ratio and screen resolution |
	| Native desktop          | Supported operating systems                            |
	| Native desktop          | Third party components required                        |
	| Native desktop          | Device capabilities required                           |

Scenario Outline: Appear on Preview - Main Sections
	When a User previews the Marketing Page
	Then the <section> section is presented

	Examples: 
	| section                 |
	| Solution description    |
	| Features                |
	| Client application type |
	| Roadmap                 |
	| Hosting type            |
	| Contact details         |
	| About supplier          |
	| Integrations            |
	#| Implementation timescales 