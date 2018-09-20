require 'date'

build_number = DateTime.now.strftime("%Y%m%d%H%M")

text = File.read("scripts/version.template.json")
new_contents = text.gsub(/<build_number>/, build_number)
File.open("version.json", "w") {|file| file.puts new_contents }