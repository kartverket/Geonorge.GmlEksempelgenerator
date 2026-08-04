// PostHog event tracking for the "Generer GML" buttons.
// Captures a single event with a `source` property distinguishing the two endpoints.

$(function () {
    if (typeof posthog === 'undefined') return;

    $('#generate-from-url-btn').on('click', function () {
        posthog.capture('generate_gml_clicked', { source: 'xsd_url' });
    });

    $('#generate-from-file-btn').on('click', function () {
        posthog.capture('generate_gml_clicked', { source: 'xsd_file' });
    });
});
