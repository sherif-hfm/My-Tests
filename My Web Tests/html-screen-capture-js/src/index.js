import OutputTypeEnum from './output-type-enum.js';
import Capturer from './capturer.js';

export const OutputType = new OutputTypeEnum();

export function capture(outputType, htmlDocument, options) {
	return (new Capturer()).capture(outputType, htmlDocument, options);
}
