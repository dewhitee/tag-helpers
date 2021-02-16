# tag-helpers

## Setup
Add the following line inside your ***_ViewImports.cshtml*** file:
```cshtml
@addTagHelper *, Dewhitee.TagHelpers
```

## Examples

### Messages
```cshtml

<!-- Primitive messages -->
<hint msg="My hint"/>
<error msg="My error message" />
<warn msg="My warning" />
<success msg="Success message"/>

<!-- You can set 'as' attribute to render message in specific way: -->
<hint msg="My hint" as="Callout" />
<error msg="My error" as="Note" />

<!-- In case Modal mode is used - 'modal-id' attribute must be set to the id of a button that triggers this modal: -->
<help-modal-btn modal-id="my-modal-button" />
<hint msg="Some text as the content of a modal" as="Modal" modal-id="my-modal-button" />

```

### Buttons
```cshtml
<create-btn />

<delete-btn />

<submit-btn />

<save-btn />

<back-btn route="@Model.PreviousRoute" />
```

### Collapse
```cshtml
<collapse-btn collapse-id="search" text="Search <i class='fas fs-search'></i>" />
<collapse collapse-id="search">
  Some content
</collapse>
```

### Modals
```cshtml
<help-modal-btn modal-id="some-help" />
<help msg="Some help text" as="Modal" modal-id="some-help" />
```


### Tabs
```cshtml
<tabs mode="Horizontal">
  <tab-buttons tabs-id="my-tabs" titles="Link 1, Link 2, Link 3"/>
  <tab-contents tabs-id="my-tabs">
    <tab-content title="Link 1" active="true">
      Link 1 content
    </tab-content>
    <tab-content title="Link 2" active="true">
      Link 2 content
    </tab-content>
    <tab-content title="Link 3" active="true">
      Link 3 content
    </tab-content>
  </tab-contents>
</tabs>
```
