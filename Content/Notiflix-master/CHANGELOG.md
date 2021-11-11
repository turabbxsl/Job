@2.4.0
* **Added:** `Notiflix.Loading.*` module: The `message` parameter has been extended, and the `options` parameter has been added.

  - Custom options can be used for each Loading element to extend the initialize settings.
    ```js
    // Only indicator
    Notiflix.Loading.Standard();

    // Loading indicator with a message
    Notiflix.Loading.Standard('Loading...');


    // NEW: v2.4.0 and the next versions
    // Loading indicator with the new options
    Notiflix.Loading.Standard(
      {
        svgSize: '19px',
      },
    );

    // NEW: v2.4.0 and the next versions
    // Loading indicator with a message, and the new options
    Notiflix.Loading.Standard(
      'Loading...',
      {
        svgSize: '23px',
      },
    );
    ```

* **Added:** `Notiflix.Block.*` module: The `message` parameter has been extended, and the `options` parameter has been added.
  - Custom options can be used for each Block element to extend the initialize settings.

* **Changed:** Code Review.

-----

@2.3.3
* **Changed:** Code Review.
* **Changed:** Prefixes for CSS.

-----

@2.3.2
* **Fixed:** `Notiflix.Block.*` module, `Remove()` function fixes and improvements for Internet Explorer(10+) compatibility.

* **Changed:** `"notiflix-aio.js"` file has been moved from `"src"` to `"src/all-in-one"` folder.

-----

@2.3.1
* **Changed:** `Notiflix.Notify.*` module, `callback` and `options` parameters have been changed.

  - Custom options can be used for each Notify element to extend the initialize settings.
    ```js
    // e.g. Message with a callback
    Notiflix.Notify.Success(
      'Click Me',
      function(){
        // callback
      },
    );

    // NEW: v2.3.1 and the next versions
    // e.g. Message with the new options
    Notiflix.Notify.Success(
      'Click Me',
      {
        timeout: 6000,
      },
    );

    // NEW: v2.3.1 and the next versions
    // e.g. Message with callback, and the new options
    Notiflix.Notify.Success(
      'Click Me',
      function(){
        // callback
      },
      {
        timeout: 4000,
      },
    );
    ```

* **Changed:** `Notiflix.Report.*` module, `callback` and `options` parameters have been changed.

* **Changed:** Code Review.

-----

@2.3.0
* **Added:** `Notiflix.Notify.*` module, `optionsOrCallback` parameter has been added. (Recommended by [VirgilioGM](https://github.com/VirgilioGM))
* **Added:** `Notiflix.Report.*` module, `optionsOrCallback` parameter has been added.
* **Changed:** Code Review.

-----

@2.2.1
* **Changed:** `Notiflix.Notify.*` module, CSS animation improvements.

-----

@2.2.0

* **Added:**
  - `Notiflix.Notify.*` module; `center-top`, `center-bottom`, and `center-center` options have been added to the `position` setting. (Recommended by [Sebastian Stavar](https://github.com/SebastianStavar))

  - `Notiflix.Notify.*` module; `backOverlayColor` option has been added to each type of notification. Can be set different background overlay colors for each type of notification now.
  (Recommended by [Sebastian Stavar](https://github.com/SebastianStavar))
    ```js
    // e.g.

    Notiflix.Notify.Init({
      // ...
      backOverlay: true, // default is false
      backOverlayColor: 'rgba(0,0,0,0.5)', // default back overlay color
      // ...
      success: {
        backOverlayColor: 'rgba(50,198,130,0.2)', // NEW: override the back overlay color
      },
      failure: {
        backOverlayColor: 'rgba(255,85,73,0.2)', // NEW: override the back overlay color
      },
      // ...
    });
    ```

  - `Notiflix.Report.*` module; `backOverlayColor` option has been added to each type of dialog box. Can be set different background overlay colors for each type of notification now.
    e.g.
    ```js
    Notiflix.Report.Init({
      success: {
        backOverlayColor: 'rgba(50,198,130,0.2)', // NEW: override the back overlay color
      },
      failure: {
        backOverlayColor: 'rgba(255,85,73,0.2)', // NEW: override the back overlay color
      },
      // ...
    });
    ```

* **Changed:** All modules (`Notify`, `Report`, `Confirm`, `Loading`, and `Block`); `useGoogleFont` setting has been changed as `false` to default.

* **Changed:** Code Review.

-----

@2.1.4
* **Changed:** Code Review.
* **Changed:** Notiflix Confirm module; HTML tag of the message element has been changed from "`p`" to "`div`".

-----

@2.1.3
* **Changed:** Code Review.

-----

@2.1.2
* **Fixed:** Document Object Model definition fixes.
* **Changed:** Code Review.

-----

@2.1.1
* **Fixed:** Document Object Model definition fixes.
* **Changed:** Code Review.

-----

@2.1.0
* **Added:** Universal Module Definition.

-----

@2.0.0

#### Notiflix `v2` is ready to use.

This version includes a new module name as `Block`.

`Notiflix.Block.*` module can be used to block or unblock elements to prevents users actions during the process (AJAX etc.) without locking the browser or the other elements.

* **Added:** The `Block` module added to `Notiflix`.

* **Added:** The `clickToClose` option added to the `Notiflix.Notify.*` module. Default is `false`. This option can be set as `true` to remove each notification without waiting for it to be automatically removed when it has been clicked. (Recommended by [Mustafa Sadedil](https://github.com/sadedil))

* **Changed:** Code Review.

-----
-----
-----
-----
-----

@1.9.1
* **Changed:** Code Review.

-----

@1.9.0
* **Changed:** Code Review.

-----

@1.8.0
* **Added:** The "showOnlyTheLastOne" option added to the "Notiflix Notify" module. (Recommended by [Ori Granot](https://github.com/origranot))

(Default is "false". This option can be set as "true" to show only the last notification.)

-----

@1.7.2
* **Added:** Unminified package published.

-----

@1.7.1
* **Changed:** Character encoding UTF-8 without BOM.

-----

@1.7.0
* **Added:** An optional callback function can be used with Deny Button in "Notiflix Confirm" module. (Recommended by [Sinan Keskin](https://github.com/sinankeskin))

-----

@1.6.0
* **Changed:** Code Review.

* **Added:** All modules can be used even if they didn't initialized. The first call will initialize the module once. (With default settings.)

-----

@1.5.0
* **Fixed:** When the "useGoogleFont" option set as "false"; the "fontFamily" option was being ineffective.

-----

@1.4.0
* **Changed:** Code Review.

-----

@1.3.0
* **Added:** The "**plainText**" options added to "**Notiflix Notify**" and "**Notiflix Confirm**" modules.

(The "**plainText**" options can be set as "**false**" to use HTML allowed contents. Default values are "**true**" and not allowed HTML)

-----

@1.2.0
* **Changed:** JavaScript event listener improvements.

-----

@1.1.0
* **Fixed:** When used with Bootstrap, CSS fade animation class name was conflicting with some of Bootstrap class names. (Reported by [Hasim Yerli](https://github.com/hasimyerli))

-----
